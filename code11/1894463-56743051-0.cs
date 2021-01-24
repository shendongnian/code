    class MainClass
    {
        class Car
        {
            public string Name
            {
                get;
                set;
            }
        }
        private static Car carInstance;
        public static void Main(string[] args)
        {
            Test();
            carInstance = new Car();
            Console.WriteLine(carInstance.Name);
        }
        public static void Test()
        {
            carInstance = new Car
            {
                Name = "Chevrolet Corvette",
            };
            Console.WriteLine("This is a test");
        }
    }
