    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Linq;
    namespace StackOverFlow
    {
        public class Employee : Entity
        {
            public string FirstName { get; set; }
            [BsonRepresentation(BsonType.ObjectId)]
            public string CityID { get; set; }
        }
        public class City : Entity
        {
            public string CityName { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test");
                var ny = new City { CityName = "New York" };
                var la = new City { CityName = "Los Angeles" };
                new[] { la, ny }.Save();
                new[] {
                    new Employee { FirstName = "NY One", CityID = ny.ID},
                    new Employee { FirstName = "NY Two", CityID = ny.ID},
                    new Employee { FirstName = "LA One", CityID = la.ID},
                    new Employee { FirstName = "LA Two", CityID = la.ID},
                }.Save();
                var result = DB.Queryable<Employee>()
                               .GroupBy(e => e.CityID)
                               .Select(g => new { employeeCount = g.Count(), cityID = g.Key })
                               .Join(DB.Queryable<City>(),
                                     x => x.cityID,
                                     c => c.ID,
                                     (x, c) => new { x.employeeCount, c.CityName })
                               .ToList();
            }
        }
    }
