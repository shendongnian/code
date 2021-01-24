csharp
using System.Collections.Generic;
using System.Linq;
using MongoDB.Entities;
namespace StackOverflow
{
    class Program
    {
        [Name("Venues")]
        public class Venue : Entity
        {
            public string Name { get; set; }
            public Dictionary<string, object> Properties { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            var venue1 = new Venue
            {
                Name = "Venue 1",
                Properties = new Dictionary<string, object>  {
                    { "Chairs", 28 },
                    { "Tables", 4 },
                    { "HasWaterfall", true }
                }
            };
            venue1.Save();
            var venue2 = new Venue
            {
                Name = "Venue 2",
                Properties = new Dictionary<string, object>  {
                    { "Chairs", 38 },
                    { "Tables", 4 },
                    { "HasWaterfall", true }
                }
            };
            venue2.Save();
            var chairs = DB.Find<Venue, object>()
                           .Match(v => v.Name == "Venue 1")
                           .Project(v => new { ChairCount = v.Properties["Chairs"] })
                           .Execute();
            var avgChairs = DB.Collection<Venue>()
                              .Average(v => (int)v.Properties["Chairs"]);
        }
    }
}
results in the following queries being made to the database:
getting chairs in venue 1:
java
db.runCommand({
    "find": "Venues",
    "filter": {
        "Name": "Venue 1"
    },
    "projection": {
        "Properties.Chairs": NumberInt("1"),
        "_id": NumberInt("0")
    },
    "$db": "test"
})
getting average chair count across all venues:
java
db.Venues.aggregate([
    {
        "$group": {
            "_id": NumberInt("1"),
            "__result": {
                "$avg": "$Properties.Chairs"
            }
        }
    }
])
