csharp
using MongoDB.Entities;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Record : Entity
        {
            public DateTime TimeStamp { get; set; }
            public double? Value { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            (new[] {
                new Record { TimeStamp = DateTime.UtcNow },
                new Record { TimeStamp = DateTime.UtcNow, Value = null },
                new Record { TimeStamp = DateTime.UtcNow, Value = 2 },
                new Record { TimeStamp = DateTime.UtcNow, Value = 2 }
            }).Save();
            var from = DateTime.UtcNow.AddMinutes(-1);
            var to = DateTime.UtcNow.AddMinutes(1);
            var result = DB.Queryable<Record>()
                           .Where(r => r.Value != null && r.TimeStamp >= from && r.TimeStamp <= to)
                           .GroupBy(r => true)
                           .Select(g => new
                           {
                               Rec = new Record { TimeStamp = from, Value = g.Average(r => r.Value) },
                               Count = g.Count()
                           })
                           .Single();
            Console.WriteLine($"Average: {result.Rec.Value}");
            Console.WriteLine($"Count: {result.Count}");
            Console.ReadKey();
        }
    }
}
the above is using my library **MongoDB.Entities** but the querying part is the same for `.AsQueryable` of the official driver.
it will produce the following aggregation query:
java
db.Record.aggregate([
    {
        "$match": {
            "Value": {
                "$ne": null
            },
            "TimeStamp": {
                "$gte": ISODate("2019-06-30T07:20:59.126Z"),
                "$lte": ISODate("2019-06-30T07:22:59.126Z")
            }
        }
    },
    {
        "$group": {
            "_id": true,
            "__agg0": {
                "$avg": "$Value"
            },
            "__agg1": {
                "$sum": NumberInt("1")
            }
        }
    },
    {
        "$project": {
            "Rec": {
                "TimeStamp": ISODate("2019-06-30T07:20:59.126Z"),
                "Value": "$__agg0"
            },
            "Count": "$__agg1",
            "_id": NumberInt("0")
        }
    }
])
