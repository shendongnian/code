    public abstract class Vehicle
    {
        public string Name { get; set; }
        public float Speed { get; set; }
    }
    public class Bus : Vehicle { }
    public class Tram : Vehicle { }
    public class Car : Vehicle { }
    public class Bike : Vehicle
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
