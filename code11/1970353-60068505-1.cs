    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Linq;
    namespace StackOverFlow
    {
        public class OrderInfo : Entity
        {
            public Product[] Products { get; set; }
        }
        public class Product
        {
            public Guid Id { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test-db");
                var input = new[] { Guid.NewGuid(), Guid.NewGuid() };
                var orders = new[] {
                    new OrderInfo {  Products = new[] { new Product { Id = input[0] } } },
                    new OrderInfo {  Products = new[] { new Product { Id = input[1] } } }
                };
                orders.Save();
                var products = DB.Queryable<OrderInfo>() // collection.AsQueryable() for official driver
                                 .Where(o => o.Products.Any(p => input.Contains(p.Id)))
                                 .SelectMany(o => o.Products)
                                 .Where(p => input.Contains(p.Id))
                                 .ToList();
            }
        }
    }
