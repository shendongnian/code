    class Base
    {
        public void SayHello() // Not virtual
        {
            Console.WriteLine("Hello from Base");
        }
    }
    
    class Derived : Base
    {
        public new void SayHello() // Hides method from base class
        {
            Console.WriteLine("Hello from Derived");
        }
    }
    static void Main()
    {
        Base x = new Base();
        x.SayHello(); // Prints "Hello from Base"
        x = new Derived();
        x.SayHello(); // Still prints "Hello from Base" because x is declared as Base
        Derived y = new Derived();
        y.SayHello(); // Prints "Hello from Derived" because y is declared as Derived
    }
