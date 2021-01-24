    internal class Plant
    {
        internal Plant()
        {
            Cars = new List<Car>();
            Cars.Add(new Car() { Model = "Scenic IV 7 pls" });
            Cars.Add(new Car() { Model = "Scenic IV 7 pls" });
            Cars.Add(new Car() { Model = "Scenic IV 7 pls" });
        }
        internal void SetEngines()
        {
            foreach (Car c in Cars)
            {
                Car.SwapEngine(c, new Engine() { Power = 100 + DateTime.Now.Millisecond });
            }
        
        }
        internal List<Car> Cars { get; private set; }
    }
    internal class Car
    {
        internal string Model { get; set; }
        internal Engine Engine { get; private set; }
        internal static Car SwapEngine(Car car, Engine newEngine)
        {
            car.Engine = newEngine;
            return car;
        }
    }
    internal class Engine
    {
        internal int Power { get; set; }
    }
