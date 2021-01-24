csharp
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
            var inputIDs = new[] { one.ID, thr.ID };
            var deletedIDs = DB.Queryable<Item>() // for official driver use: collection.AsQueryable()
                               .Where(i => !inputIDs.Contains(i.ID))
                               .Select(i => i.ID)
                               .ToArray();
            var commonIDs = inputIDs.Except(deletedIDs);
        }
    }
}
