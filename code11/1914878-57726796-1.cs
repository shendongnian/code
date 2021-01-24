    using MongoDB.Entities;
    using System.Linq;
    namespace StackOverflow
    {
        public class Program
        {
            public class StorageModel : Entity
            {
                public string DriverID { get; set; }
                public Car[] OwnedCars { get; set; }
            }
            public class Car
            {
                public string PlateNumber { get; set; }
                public string Color { get; set; }
            }
            private static void Main(string[] args)
            {
                new DB("test");
                (new StorageModel
                {
                    DriverID = "321",
                    OwnedCars = new[]
                     {
                         new Car { PlateNumber = "ABC123", Color = "Red"}
                     }
                }).Save();
                var updatedCar = new Car { PlateNumber = "ABC123", Color = "White" };
                var bulk = DB.Update<StorageModel>();
                bulk.Match(s => s.DriverID == "321" &&
                               !s.OwnedCars.Any(c => c.PlateNumber == updatedCar.PlateNumber))
                    .Modify(b => b.Push(s => s.OwnedCars, updatedCar))
                    .AddToQueue();
                bulk.Match(s => s.DriverID == "321" &&
                                s.OwnedCars.Any(c => c.PlateNumber == updatedCar.PlateNumber))
                    .Modify(b => b.Set(s => s.OwnedCars[-1], updatedCar))
                    .AddToQueue();
                bulk.Execute();
            }
        }
    }
