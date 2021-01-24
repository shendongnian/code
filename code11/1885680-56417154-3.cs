csharp
using MongoDB.Driver;
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class Book : Entity
        {
            public string Name { get; set; }
            public Many<City> Cities { get; set; }
            public Book() => this.InitOneToMany(() => Cities);
        }
        public class City : Entity
        {
            public string Name { get; set; }
            public Coordinates2D Location { get; set; }
            public double DistanceKM { get; set; }
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
                Location = new Coordinates2D(48.8539241, 2.2913515)
            };
            paris.Save();
            var versailles = new City
            {
                Name = "versailles",
                Location = new Coordinates2D(48.796964, 2.137456)
            };
            versailles.Save();
            var poissy = new City
            {
                Name = "poissy",
                Location = new Coordinates2D(48.928860, 2.046889)
            };
            poissy.Save();
            var scifi = new Book { Name = "sci-fi" };
            scifi.Save();
            scifi.Cities.Add(paris);
            scifi.Cities.Add(versailles);
            scifi.Cities.Add(poissy);
            var horror = new Book { Name = "horror" };
            horror.Save();
            horror.Cities.Add(poissy);
            var eiffelTower = new Coordinates2D(48.857908, 2.295243);
            //find matching city IDs within 20kms of eiffel tower.
            var cities = DB.GeoNear<City>(
                            NearCoordinates: eiffelTower,
                            DistanceField: c => c.DistanceKM,
                            MaxDistance: 20000);
            //get books with matching cities
            var books = DB.Entity<Book>()
                          .Cities.ParentsFluent<Book>(cities)
                          .ToList();
        }
    }
}
the above program issues the following aggregation query to mongodb:
first query:
javascript
{
    "$geoNear": {
        "near": {
            "type": "Point",
            "coordinates": [
                48.857908,
                2.295243
            ]
        },
        "distanceField": "DistanceKM",
        "spherical": true,
        "maxDistance": NumberInt("20000")
    }
}, {
    "$lookup": {
        "from": "[Book~City(Cities)]",
        "localField": "_id",
        "foreignField": "ChildID",
        "as": "Results"
    }
}, {
    "$replaceRoot": {
        "newRoot": {
            "$arrayElemAt": [
                "$Results",
                NumberInt("0")
            ]
        }
    }
}, {
    "$lookup": {
        "from": "Book",
        "localField": "ParentID",
        "foreignField": "_id",
        "as": "Results"
    }
}, {
    "$replaceRoot": {
        "newRoot": {
            "$arrayElemAt": [
                "$Results",
                NumberInt("0")
            ]
        }
    }
}, {
    "$group": {
        "_id": "$_id",
        "doc": {
            "$first": "$$ROOT"
        }
    }
}, {
    "$replaceRoot": {
        "newRoot": "$doc"
    }
}
