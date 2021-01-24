    class Program
    {
        static void Main()
        {
            var class1 = new Class1();
            class1.Setup();
            Console.Write(class1.Property1);
            Console.ReadKey();
        }
    }
    class Class1
    {
        public string Property1 { get; set;}
        public Class1 ()
        {
            this.Property1 = "Overwrite me";
        }
        public void Setup()
        {
            this.Property1 = "Successfully overwritten";
        }
    }
