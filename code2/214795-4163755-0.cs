    class Program
    {
        static void Main(string[] args)
        {
            A.SomeField = false;
        }
    }
    class A
    {
        static A()
        {
            Console.WriteLine("Static A");
        }
        public static bool SomeField;
    }
    class B
    {
        static B()
        {
            Console.WriteLine("Static B");
        }
    }
