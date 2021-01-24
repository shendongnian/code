csharp
using MongoDB.Entities;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Tag : Entity
        {
            public string Name { get; set; }
            public Many<City> Cities { get; set; }
            public Tag() => this.InitOneToMany(() => Cities);
        }
        public class City : Entity
        {
            public string Name { get; set; }
            public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            //create an index
            DB.Index<City>()
              .Key(c => c.Location, KeyType.Geo2DSphere)
              .Option(o => o.Background = false)
              .Create();
            var paris = new City
            {
                Name = "paris",
                Location = GeoJson.Point(new GeoJson2DGeographicCoordinates(48.8539241, 2.2913515))
            };
            paris.Save();
            var versailles = new City
            {
                Name = "versailles",
                Location = GeoJson.Point(new GeoJson2DGeographicCoordinates(48.796964, 2.137456))
            };
            versailles.Save();
            var poissy = new City
            {
                Name = "poissy",
                Location = GeoJson.Point(new GeoJson2DGeographicCoordinates(48.928860, 2.046889))
            };
            poissy.Save();
            var scifi = new Tag { Name = "sci-fi" };
            scifi.Save();
            scifi.Cities.Add(paris);
            scifi.Cities.Add(versailles);
            scifi.Cities.Add(poissy);
            var horror = new Tag { Name = "horror" };
            horror.Save();
            horror.Cities.Add(poissy);
            var eiffelTower = GeoJson.Point(GeoJson.Geographic(48.857908, 2.295243));
            //find matching city IDs within 20kms of eiffel tower.
            var cities = DB.Find<City, string>()
                           .Match(f => f.NearSphere(c => c.Location, eiffelTower, 20000))
                           .Project(c => c.ID)
                           .Execute();
            var x = DB.Collection<City>();
            //get tags with matching cities
            var tags = DB.Entity<Tag>()
                         .Cities.ParentsQueryable<Tag>(cities)
                         .ToArray();
        }
    }
}
the above program issues 2 queries to mongodb which are as follows
first query:
javascript
{
    "find": "City",
    "filter": {
        "Location": {
            "$nearSphere": {
                "$geometry": {
                    "type": "Point",
                    "coordinates": [
                        48.857908,
                        2.295243
                    ]
                },
                "$maxDistance": 20000
            }
        }
    },
    "projection": {
        "_id": NumberInt("1")
    }
second query:
javascript
{
    "$match": {
        "ChildID": {
            "$in": [
                ObjectId("5cf3fc1f4090311b6415b75d"),
                ObjectId("5cf3fc1f4090311b6415b75e")
            ]
        }
    }
}, {
    "$lookup": {
        "from": "Tag",
        "localField": "ParentID",
        "foreignField": "_id",
        "as": "t"
    }
}, {
    "$unwind": "$t"
}, {
    "$group": {
        "_id": "$t"
    }
}
