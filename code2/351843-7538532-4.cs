    class BaseClass
    {
        public virtual string SayHi()
        {
            return ("Hi");
        }
    }
    
    class DerivedClass : BaseClass
    {
        public override string SayHi()
        {
            return (base.SayHi() + " from derived");
        }
    }
    
    class Program
    {
        static void Main()
        {
            BaseClass d = new DerivedClass();
            // the child SayHi method is invoked
            Console.WriteLine(d.SayHi()); // prints "Hi from derived"
        }
    }
