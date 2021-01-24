java
db.Parent.aggregate([
    {
        "$match": {
            "items": {
                "$elemMatch": {
                    "details.zone.name": "second zone"
                }
            }
        }
    }
])
if you want to get only the matching sub documents (items), you need `$unwind` and `$project` like so:
java
db.Parent.aggregate([
    {
        "$unwind": "$items"
    },
    {
        "$project": {
            "items": "$items",
            "_id": NumberInt("0")
        }
    },
    {
        "$match": {
            "items.details.zone.name": "second zone"
        }
    }
])
here's the c# code that generated above queries. code uses MongoDB.Entities for brevity. the querying part is the same for the official driver. just use `collection.AsQueryable()` in place of `DB.Queryable<Parent>()`
csharp
using MongoDB.Driver.Linq;
using MongoDB.Entities;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Parent : Entity
        {
            public Item[] items { get; set; }
        }
        public class Item
        {
            public string id { get; set; }
            public Detail details { get; set; }
        }
        public class Detail
        {
            public string id { get; set; }
            public Zone zone { get; set; }
        }
        public class Zone
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            (new[] {
                new Parent {
                items = new[]
                {
                    new Item
                    {
                        id = Guid.NewGuid().ToString(),
                        details = new Detail
                        {
                            id = Guid.NewGuid().ToString(),
                            zone = new Zone
                            {
                                id = Guid.NewGuid().ToString(),
                                name = "first zone"
                            }
                        }
                    }
                }
            },
                new Parent {
                items = new[]
                {
                    new Item
                    {
                        id = Guid.NewGuid().ToString(),
                        details = new Detail
                        {
                            id = Guid.NewGuid().ToString(),
                            zone = new Zone
                            {
                                id = Guid.NewGuid().ToString(),
                                name = "second zone"
                            }
                        }
                    }
                }
            }
            }).Save();
            //get all Parent entities that have 'second zone'
            var roots = DB.Queryable<Parent>()
                          .Where(p => p.items.Any(i => i.details.zone.name == "second zone"))
                          .ToArray();
            //get only items that have 'second zone'
            var items = DB.Queryable<Parent>()
                          .SelectMany(p => p.items)
                          .Where(i => i.details.zone.name == "second zone")
                          .ToArray();
        }
    }
}
