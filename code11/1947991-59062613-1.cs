    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Linq;
    namespace StackOverflow
    {
        public class Item : Entity
        {
            public Version[] Versions { get; set; }
        }
        public class Version
        {
            public string Barcode { get; set; }
        }
        public class Program
        {
            private static void Main(string[] args)
            {
                new DB("test", "localhost");
                var result = DB.Queryable<Item>()
                               .SelectMany(i => i.Versions)
                               .OrderByDescending(v => v.Barcode)
                               .Take(1)
                               .Single();
                Console.WriteLine($"max barcode: {result.Barcode}");
                Console.Read();
            }
        }
    }
