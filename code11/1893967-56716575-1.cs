java
db.Customer.find({
    "$or": [
        {
            "DOB": {
                "$lte": ISODate("1989-06-22T14:57:50.168Z"),
                "$gte": ISODate("1988-06-22T14:57:50.168Z")
            }
        },
        {
            "DOB": {
                "$lte": ISODate("1987-06-22T14:57:50.168Z"),
                "$gte": ISODate("1986-06-22T14:57:50.168Z")
            }
        },
        {
            "DOB": {
                "$lte": ISODate("1984-06-22T14:57:50.168Z"),
                "$gte": ISODate("1983-06-22T14:57:50.168Z")
            }
        }
    ]
})
here's the c# code that generated the above find query using the convenience library [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities) [disclaimer: i'm the author]
csharp
using MongoDB.Driver;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
namespace StackOverflow
{
    public class Program
    {
        public class Customer : Entity
        {
            public string Name { get; set; }
            public DateTime DOB { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            (new[] {
                new Customer{ Name = "I am 29", DOB = DateTime.UtcNow.AddYears(-29)},
                new Customer{ Name = "I am 30", DOB = DateTime.UtcNow.AddYears(-30)},
                new Customer{ Name = "I am 32", DOB = DateTime.UtcNow.AddYears(-32)},
                new Customer{ Name = "I am 35", DOB = DateTime.UtcNow.AddYears(-35)},
                new Customer{ Name = "I am 36", DOB = DateTime.UtcNow.AddYears(-36)}
            }).Save();
            var ages = new[] { 30, 32, 35 };
            var filters = new List<FilterDefinition<Customer>>();
            foreach (var age in ages)
            {
                var start = DateTime.UtcNow.AddYears(-age);
                var end = DateTime.UtcNow.AddYears(-age - 1);
                filters.Add(
                    Builders<Customer>.Filter
                                      .Where(c => c.DOB <= start && c.DOB >= end));
            }
            var customers = DB.Find<Customer>()
                              .Many(f => f.Or(filters))
                              .ToArray();
        }
    }
}
