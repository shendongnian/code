csharp
using MongoDB.Entities;
using MongoDB.Driver.Linq;
using System.Linq;
namespace StackOverflow
{
    public class Location : Entity
    {
        public string LocationNumber { get; set; }
    }
    public class LocationInfo : Entity
    {
        public string LocationName { get; set; }
        public ServiceLocation[] ServiceLocation { get; set; }
    }
    public class ServiceLocation
    {
        public string LocationId { get; set; }
        public Address[] Addresses { get; set; }
    }
    public class Address
    {
        public string AddressId { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("Location");
            var res = 
            DB.Queryable<LocationInfo>()
              .SelectMany(li => li.ServiceLocation, //unwind the service locations
                               (li, sl) => new { locName = li.LocationName, serLoc = sl }) //project needed data in to anonymous type
              .Join(DB.Queryable<Location>(), //foregin collection
                    x => x.serLoc.LocationId, //local field in anonymous type from unwind above
                    l => l.ID,                //foreign field
                    (x, l) => new { LocationName = x.locName, ServiceLocation = x.serLoc }) //project in to final anonymous type
              .ToList();
        }
    }
}
