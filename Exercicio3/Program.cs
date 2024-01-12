using Exercicio3.Entities;
using Exercicio3.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            string sts = Console.ReadLine();
            OrderStatus status =(OrderStatus)Enum.Parse(typeof(OrderStatus), sts, true); 

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int items = int.Parse(Console.ReadLine());

            for(int i = 1; i < items; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string pn = Console.ReadLine();
                Console.Write("Product Price: ");
                double pr = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(pn, pr);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrdemItem ordemItem = new OrdemItem(quantity, pr, product);
                
                order.AddProduct(ordemItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}
