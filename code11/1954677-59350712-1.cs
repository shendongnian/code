    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    namespace StackOverflow
    {
        [Name("Vehicles")]
        public class Vehicle : Entity
        {
            public string Type { get; set; }
            public string UserID { get; set; }
            public string Color { get; set; }
        }
        [Name("Vehicles")]
        public class Car : Vehicle
        {
            public string TireType { get; set; }
        }
        [Name("Vehicles")]
        public class Truck : Vehicle
        {
            public string FuelType { get; set; }
        }
        public class Program
        {
            private static void Main(string[] args)
            {
                new DB("test", "localhost");
                (new Car { UserID = "xxx", Type = "car", Color = "red", TireType = "summer" }).Save();
                (new Car { UserID = "xxx", Type = "car", Color = "white", TireType = "winter" }).Save();
                (new Truck { UserID = "xxx", Type = "truck", Color = "black", FuelType = "diesel" }).Save();
                var result = DB.Find<Vehicle>()
                               .Match(f =>
                                      f.Eq(v => v.UserID, "xxx") &
                                      f.Ne("TireType", "winter"))
                               .Sort(v => v.ID, Order.Descending)
                               .Limit(32)
                               .Execute();
                //var result = DB.Collection<Vehicle>().Find(
                //                Builders<Vehicle>.Filter.Eq(v => v.UserID, "xxx") &
                //                Builders<Vehicle>.Filter.Ne("TireType", "winter"))
                //               .Limit(32)
                //               .ToList();
            }
        }
    }
