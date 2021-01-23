    class Base
    {
        public virtual void foo()
        {
            System.Console.WriteLine("base");
        }
    }
 
    class Derived
        : Base
    {
        static void Main(string[] args)
        {
            Base b = new Base();
            b.foo();
            b = new Derived();
            b.foo();
 
        }
 
        public override void foo()
        {
            System.Console.WriteLine("derived");
        }
    }
