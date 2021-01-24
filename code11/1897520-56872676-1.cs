csharp
using MongoDB.Entities;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Hotel : Entity
        {
            public string Name { get; set; }
            public int[] Amenities { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            (new[] {
                new Hotel{ Name= "hotel one", Amenities = new[] {1, 3, 5, 7 } },
                new Hotel{ Name= "hotel two", Amenities = new[] {2, 4, 6, 8 } }
            }).Save();
            string amenities = "2,4,6,8";
            int[] amenityList = amenities.Split(",").Select(a => Convert.ToInt32(a)).ToArray();
            var result = DB.Find<Hotel>()
                           .Many(h => amenityList.All(a => h.Amenities.Contains(a)));
        }
    }
}
it generates the following find query:
java
"command": {
    "find": "Hotel",
    "filter": {
        "Amneties": {
            "$all": [
                NumberInt("2"),
                NumberInt("4"),
                NumberInt("6"),
                NumberInt("8")
            ]
        }
    }
}
