    class Base
    {
        static Base()
        {
            Console.WriteLine("Base static constructor called.");
        }
    
        internal static void Initialize() { }
    }
    class Derived : Base
    {
        static Derived()
        {
            Initialize(); //Removing this will cause the Base static constructor not to be executed.
            Console.WriteLine("Derived static constructor called.");
        }
    
        public static void DoStaticStuff()
        {
            Console.WriteLine("Doing static stuff.");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Derived.DoStaticStuff();
        }
    }
