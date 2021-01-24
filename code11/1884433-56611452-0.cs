csharp
using MongoDB.Entities;
using MongoDB.Driver;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Announcement : Entity
        {
            public Coordinates2D CollectionLocation { get; set; }
            public Coordinates2D DepositLocation { get; set; }
            public double DistanceMeters { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            DB.Index<Announcement>()
              .Key(a => a.CollectionLocation, KeyType.Geo2DSphere)
              .Create();
            DB.Index<Announcement>()
              .Key(a => a.DepositLocation, KeyType.Geo2DSphere)
              .Create();
            (new Announcement
            {
                DepositLocation = new Coordinates2D(48.8539241, 2.2913515),
                CollectionLocation = new Coordinates2D(48.796964, 2.137456)
            }).Save();
            var searchPointA = new Coordinates2D(48.796964, 2.137456);
            var queryA = DB.GeoNear<Announcement>(
                                NearCoordinates: searchPointA,
                                DistanceField: a => a.DistanceMeters,
                                IndexKey: "CollectionLocation",
                                MaxDistance: 10);
            var searchPointB = new Coordinates2D(48.8539241, 2.2913515);
            var queryB = DB.GeoNear<Announcement>(
                                NearCoordinates: searchPointB,
                                DistanceField: a => a.DistanceMeters,
                                IndexKey: "DepositLocation",
                                MaxDistance: 10);
            var resultA = queryA.ToList();
            var resultB = queryB.ToList();
            var common = resultA.Where(a => resultB.Any(b => b.ID == a.ID)).ToArray();
        }
    }
}
the following two $geoNear queries will be issued to find the locations:
java
[
    {
        "$geoNear": {
            "near": {
                "type": "Point",
                "coordinates": [
                    48.8539241,
                    2.2913515
                ]
            },
            "distanceField": "DistanceMeters",
            "spherical": true,
            "maxDistance": NumberInt("10"),
            "key": "DepositLocation"
        }
    }
]
[
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
            "maxDistance": NumberInt("10"),
            "key": "CollectionLocation"
        }
    }
]
