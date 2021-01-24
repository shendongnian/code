csharp
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace StackOverflow
{
    public class Document : Entity
    {
        public List<SubDocument> SubDocs { get; set; } = new List<SubDocument>();
        public int SubDocCount() => 
                   DB.Queryable<Document>()
                     .Where(d => d.ID == ID)
                     .Select(d => d.SubDocs.Count())
                     .SingleOrDefault();
    }
    public class SubDocument
    {
        public string Name { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("test");
            var doc = new Document();
            doc.Save();
            var sub1 = new SubDocument { Name = "houston" };
            var sub2 = new SubDocument { Name = "california" };
            for (int i = 0; i <= 5; i++)
            {
                DB.Update<Document>()
                  .Match(d => d.ID == doc.ID)
                  .Modify(b => b.AddToSet(d => d.SubDocs, sub1))
                  .Execute();
                DB.Update<Document>()
                  .Match(d => d.ID == doc.ID)
                  .Modify(b => b.AddToSet(d => d.SubDocs, sub2))
                  .Execute();
            }
            Console.WriteLine($"sub document count is: {doc.SubDocCount()}"); // result is 2
            Console.Read();
        }
    }
}
above code uses my library [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities) for brevity. if you need help converting it to official driver code, let me know.
also do test it in a mult-threaded (multi-service) environment and share with us if it results in duplicates. but i'm assuming `$addToSet` would prevent that from happening.
