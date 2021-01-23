    class Base
    {
        public virtual void SayHello()
        {
            Console.WriteLine("Hello from Base");
        }
    }
    
    class Derived : Base
    {
        public override void SayHello()
        {
            Console.WriteLine("Hello from Derived");
        }
    }
    static void Main()
    {
        Base x = new Base();
        x.SayHello(); // Prints "Hello from Base"
        x = new Derived();
        x.SayHello(); // Prints "Hello from Derived"
    }
