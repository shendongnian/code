    static void Main(string[] args)
    {
        Console.WriteLine(GetMaxSpeed(Car.Ferrari));
        Console.ReadLine();
    }
    public static int GetMaxSpeed(Car ModelType)
    {
        switch (ModelType.Id)
        {
            case Car.Ferrari.Id:
                return Car.Ferrari.MaxSpeed;
            case Car.VW.Id:
                return Car.VW.MaxSpeed;
            case Car.AstonMartin.Id:
                return Car.AstonMartin.MaxSpeed;
        }
    }
    public class Car
    {
        public int MinSpeed;
        public int MaxSpeed;
        internal int Id;
        public Car(int MinSpeed, int MaxSpeed)
        {
            this.MinSpeed = MinSpeed;
            this.MaxSpeed = MaxSpeed;
        }
        public static Car Ferrari = new Car(30, 240){Id = 1};
        public static Car VW = new Car(10, 50){Id = 2};
        public static Car AstonMartin = new Car(75, 180){Id = 3};
    }
