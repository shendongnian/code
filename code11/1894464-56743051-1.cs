    class MainClass
    {
        class Car
        {
            public string Name { get; set; }
        }
        // This static instance will be shared amongst the static methods
        private static Car carInstance;
        public static void Main(string[] args)
        {
            Test();
            Console.WriteLine(carInstance.Name);
        }
        public static void Test()
        {
            carInstance = new Car { Name = "Chevrolet Corvette" };
            Console.WriteLine("This is a test");
        }
    }
