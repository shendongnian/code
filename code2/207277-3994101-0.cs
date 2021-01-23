    public class Car
    {
        public string Model { get; set; }
    }
    public delegate void TransformHandler(Car car);
    public static void Transform(Car car)
    {
        car.Model = "Holden";
    }
    static void Main(string[] args)
    {
        Car car = new Car();
        car.Model = "Ford";
        new TransformHandler(Transform).BeginInvoke(car, null, null);
        Thread.Sleep(100);
        Console.WriteLine(car.Model); // Prints "Holden"
    }
