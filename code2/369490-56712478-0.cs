csharp
using MongoDB.Driver;
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class Cafe : Entity
        {
            public string Name { get; set; }
            public Coordinates2D Location { get; set; }
            public double DistanceMeters { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            DB.Index<Cafe>()
              .Key(c => c.Location, KeyType.Geo2DSphere)
              .Create();
            (new Cafe
            {
                Name = "Coffee Bean",
                Location = new Coordinates2D(48.8539241, 2.2913515),
            }).Save();
            var searchPoint = new Coordinates2D(48.796964, 2.137456);
            var cafes = DB.GeoNear<Cafe>(
                               NearCoordinates: searchPoint,
                               DistanceField: c => c.DistanceMeters,
                               MaxDistance: 20000)
                          .ToList();
        }
    }
}
the above code sends the following query to mongodb server:
java
db.Cafe.aggregate([
    {
        "$geoNear": {
            "near": {
                "type": "Point",
                "coordinates": [
                    48.796964,
                    2.137456
                ]
            },
            "distanceField": "DistanceMeters",
            "spherical": true,
            "maxDistance": NumberInt("20000")
        }
    }
])
