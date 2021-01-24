    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Linq;
    namespace StackOverFlow
    {
        public class Product : Entity
        {
            public int NonUniqueId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test");
                var result = DB.Queryable<Product>()
                               .Where(p => p.Name == "book")
                               .OrderBy(p => p.Price)
                               .GroupBy(p => p.NonUniqueId)
                               .Select(g => new Product
                               {
                                   ID = g.First().ID,
                                   Name = g.First().Name,
                                   NonUniqueId = g.First().NonUniqueId,
                                   Price = g.First().Price
                               })
                               .ToList();
            }
        }
    }
