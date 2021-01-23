    class Program
    {
        class Car
        {
            // NOTE: this can't have the same name as the static method
            public virtual string CarType     
            {
                get { return ID; }
            }
            public static string ID { get { return "car"; } }
        }
    
        class SuperCar : Car
        {
            // NOTE: this can't have the same name as the static method
            public override string CarType     
            {
                get { return ID; }
            }
            public static string ID { get { return "super car"; } }
        }
    
        static void Main(string[] args)
        {
            Car a = new Car();
            Console.WriteLine(a.CarType);
            a = new SuperCar();
            Console.WriteLine(a.CarType);
        }
    }
