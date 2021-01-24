using System;
using System.Linq;
using MongoDAL;
namespace BusRoutes
{
    class Route : Entity
    {
        public string name { get; set; }
        public bool isActive { get; set; }
        public Bus[] buses { get; set; }
    }
    class Bus
    {
        public int capacity { get; set; }
        public string time { get; set; }
        public string direction { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("busroutes");
            var routeA = new Route
            {
                name = "Route A",
                buses = new Bus[]
                {
                    new Bus { capacity = 15, direction = "Inbound", time = "8:00:00"},
                    new Bus { capacity = 25, direction = "Outbound", time = "9:00:00" },
                    new Bus { capacity = 35, direction = "Inbound", time = "10:00:00" }
                }
            };
            routeA.Save();
            var query = routeA.Collection()
                .Where(r => r.ID == routeA.ID)
                .SelectMany(r => r.buses);
            Console.WriteLine(query.ToString());
            var busesOfRouteA = query.ToArray();
            foreach (var bus in busesOfRouteA)
            {
                Console.WriteLine(bus.time.ToString());
            }
            Console.ReadKey();
        }
    }
}
