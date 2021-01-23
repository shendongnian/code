    class Program
    {
        static void Main(string[] args)
        {
            A.SomeField = new B();
        }
    }
    class A
    {
        static A()
        {
            Console.WriteLine("Static A");
        }
        public static B SomeField { get; set; }
    }
    class B
    {
        static B()
        {
            Console.WriteLine("Static B");
        }
    }
