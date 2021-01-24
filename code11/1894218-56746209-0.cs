csharp
using MongoDB.Entities;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace StackOverflow
{
    public class Program
    {
        public class Product : Entity
        {
            public string Description { get; set; }
            public double Price { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test-transacion-locking", "localhost", 27017);
            
            (new Product {
                Description = "television",
                Price = 399 }
            ).Save();
            Task.Run(() =>
            {
                using (var TN = new Transaction())
                {
                    var sw1 = new Stopwatch(); sw1.Start();
                    Console.WriteLine("transaction started...");
                    DB.Update<Product>()
                      .Match(p => p.Price == 399)
                      .Modify(p => p.Price, 499)
                      .Modify(p => p.Description, "updated television")
                      .Execute();
                    TN.Save(new Product { Description = "radio", Price = 199 }); ;
                    Task.Delay(10000).Wait(); //wait 10 seconds before commiting
                    TN.Commit();
                    Console.WriteLine($"transaction took: {sw1.Elapsed.TotalSeconds} seconds");
                }
            });
            Task.Delay(10).Wait(); //wait 10 millis to let the transaction begin first
            var sw2 = new Stopwatch(); sw2.Start();
            Console.WriteLine("tv count query started...");
            var tvCount = DB.Queryable<Product>()
                            .Where(p => p.Description.Contains("television"))
                            .Count();
            Console.WriteLine($"found {tvCount} televisions in {sw2.Elapsed.TotalSeconds} seconds");
            Console.ReadKey();
        }
    }
}
this is my output:
transaction started...
tv count query started...
found 1 televisions in 0.0986646 seconds
transaction took: 10.1092237 seconds
