csharp
using MongoDB.Bson;
using MongoDB.Entities;
using MongoDB.Entities.Core;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Item : Entity
    {
        public string Name { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("test", "localhost");
            var one = new Item { Name = "one" }; one.Save();
            var two = new Item { Name = "two" }; two.Save();
            var thr = new Item { Name = "three" }; thr.Save();
            var inputIDs = new[] { one.ID, two.ID, ObjectId.GenerateNewId().ToString() };
            var validIDs = DB.Queryable<Item>() // for official driver use: collection.AsQueryable()
                               .Where(i => inputIDs.Contains(i.ID))
                               .Select(i => i.ID)
                               .ToArray();
            var deletedIDs = inputIDs.Except(validIDs).ToArray();
        }
    }
}
this should theoritically be faster than your seconds method above because it doesn't cause a projection of every ID in the collection. if this approach is acceptable for you, i'd be interested in knowing how many milliseconds it takes mongodb to finish this task for 80 million docs.
