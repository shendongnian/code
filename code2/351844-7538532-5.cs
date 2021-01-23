    class BaseClass
    {
        public string SayHi()
        {
            return ("Hi");
        }
    }
    
    class DerivedClass : BaseClass
    {
        public new string SayHi()
        {
            return (base.SayHi() + " from derived");
        }
    }
    
    class Program
    {
        static void Main()
        {
            BaseClass d = new DerivedClass();
            // the base SayHi method is invoked => no polymorphism
            Console.WriteLine(d.SayHi()); // prints "Hi"
        }
    }
