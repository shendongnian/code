    using System;
    
    struct Foo
    {
        public override bool Equals(object other)
        {
            Console.WriteLine("Foo.Equals called!");
            return true;
        }
        
        public override int GetHashCode()
        {
            return 1;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            object first = new Foo();
            object second = new Foo();
            first.Equals(second);
        }
    }
