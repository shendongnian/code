    using System;
    
    class Car
    {
        public string Color;
        public string Model;
        public string Made;
    }
    
    class Example
    {
        static void Main()
        {
            var car = new Car
            {
                Color = "Red",
                Model = "NISSAN",
                Made = "Japan"
            };
    
            foreach (var field in typeof(Car).GetFields())
            {
                Console.WriteLine("{0}: {1}", field.Name, field.GetValue(car));
            }
        }    
    }
