    class Program 
    {
        class Base
        {
            public Base()
            {
                Console.WriteLine("base ctor");
            }
        }
    
        class Derived : Base
        {
            public Derived()
            {
                Console.WriteLine("derived ctor");
            }
        }
    
        static void Main()
        {
            new Derived();
        }
    }
