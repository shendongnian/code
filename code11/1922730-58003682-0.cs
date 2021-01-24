csharp
using MongoDB.Driver;
using MongoDB.Entities; // Install-Package MongoDB.Entities
namespace StackOverflow
{
    public class Program
    {
        public class Cafe : Entity
        {
            public string Name { get; set; }
            public Coordinates2D Location { get; set; }
            public double distanceField { get; set; }
        }
        private static void Main(string[] args)
        {
            // connect to mongodb
            new DB("test", "localhost");
            // define an index
            DB.Index<Cafe>()
              .Key(c => c.Location, KeyType.Geo2DSphere)
              .Create();
            // define a search point
            var searchPoint = new Coordinates2D(-2.11, 52.55);
            // initial query
            var query = DB.GeoNear<Cafe>(
                                NearCoordinates: searchPoint,
                                DistanceField: c => c.distanceField,
                                MaxDistance: 50000,
                                Spherical: true)
                          .SortByDescending(c => c.distanceField);
            // add another stage to above query
            var coffeeBeans = query.Match(c => c.Name == "Coffee Bean");
            // retrieve entities
            var result = coffeeBeans.ToList();
        }
    }
}
