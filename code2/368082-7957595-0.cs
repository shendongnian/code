    static void Main(string[] args)
    {
        Console.WriteLine(GetMaxSpeed(Car.Ferarri));
        Console.ReadLine();
    }
    public static int GetMaxSpeed(string ModelType)
    {
        foreach(var car in Car.Cars)
           if(car.Name == ModelType)
              return car.MaxSpeed;
    }
    public enum Car
    {
        public int MinSpeed;
        public int MaxSpeed;
        public string Name;
        public Car(string Name, int MinSpeed, int MaxSpeed)
        {
            this.Name = Name;
            this.MinSpeed = MinSpeed;
            this.MaxSpeed = MaxSpeed;
        }
        
        public static List<Car> Cars = new List<Car>
        {
           new Car(Car.Ferrari, 30, 240);
           new Car(Car.VW, 10, 50);
           new Car(Car.AstonMartin, 75, 180);        
        }
        public static const string Ferrari = "Ferrari";
        public static const string VW = "VW";
        public static const string AstonMartin= "AstonMartin";
    }
