csharp
using MongoDB.Entities;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Customer : Entity
        {
            public string Name { get; set; }
            public Many<Order> Orders { get; set; }
            public Customer() => this.InitOneToMany(() => Orders);
        }
        public class Order : Entity
        {
            public One<Customer> Customer { get; set; }
            public OrderItem[] Items { get; set; }
        }
        public class Product : Entity
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        public class OrderItem //embedded entity inside order
        {
            public One<Product> Product { get; set; }
            public int Quantity { get; set; }
        }
        private static void Main(string[] args)
        {
            //initialize db connection
            new DB("cafe-db", "localhost", 27017);
            //create some products
            var cake = new Product { Name = "Cake", Price = 9.99m };
            var coffee = new Product { Name = "Coffee", Price = 6.66m };
            cake.Save();
            coffee.Save();
            //create a customer
            var customer = new Customer { Name = "Mike Posner" };
            customer.Save();
            //create an order
            var order = new Order
            {
                Customer = customer.ToReference(),
                Items = (new[]
                {
                    new OrderItem {
                        Product = cake.ToReference(),
                        Quantity = 2
                    },
                    new OrderItem {
                        Product = coffee.ToReference(),
                        Quantity = 1
                    }
                })
            };
            order.Save();
            //link the order to the customer
            customer.Orders.Add(order);
            // retrieve the data needed to generate an order summary/ invoice given just an order id
            var orderID = order.ID;
            var result = DB.Queryable<Order>()
                           .Where(o => o.ID == orderID)
                           .SelectMany(o => o.Items,
                                            (o, i) => new { productID = i.Product.ID, productQTY = i.Quantity })
                           .Join(
                                DB.Queryable<Product>(),  //foregign collection
                                x => x.productID,         //local field
                                p => p.ID,                //foreign field
                                (x, p) => new             //projection
                                {
                                    productName = p.Name,
                                    productPrice = p.Price,
                                    productQty = x.productQTY
                                })
                           .ToList();
            var customerName = DB.Find<Order>()
                                 .One(orderID)
                                 .Customer.ToEntity()
                                 .Name;
            Console.WriteLine($"CUSTOMER: {customerName}");
            foreach (var x in result)
            {
                Console.WriteLine($"PRODCUT: {x.productName} | QTY: {x.productQty} | PRICE: {x.productPrice}");
            }
            Console.Read();
        }
    }
}
