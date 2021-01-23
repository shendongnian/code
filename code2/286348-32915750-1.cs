        static void Main(string[] args)
        {
            var cars = new []
            {
                new Car {Model = "Audi", Make = "A4", Color = "Black"},
                new Car {Model = "Audi", Make = "A8", Color = "Red"},
                new Car {Model = "Audi", Make = "TT", Color = "Black"},
                new Car {Model = "Volvo", Make = "XC90", Color = "Black"},
                new Car {Model = "Volvo", Make = "S90", Color = "Black"},
                new Car {Model = "Ferrari", Make = "F500", Color = "Yellow"},
                new Car {Model = "Ferrari", Make = "F500", Color = "Red"},
                new Car {Model = "Lada", Make = "Limousine", Color = "Rusty"}
            };
            var groupedCars = cars.DistinctBy(c => new {c.Model, c.Color});
            foreach (var gc in groupedCars)
            {
                Console.WriteLine(gc.ToString()); 
            }
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey(); 
        }
        // Define other methods and classes here
    }
