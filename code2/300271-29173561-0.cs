    using System;
    class Base
    {
        protected virtual string foo()
        {
            return "Base";
        }
        public void ExhibitSubclassDependentBehavior()
        {
            Console.WriteLine("Hi, I am {0} and {1}.", GetType(), foo());
        }
    }
    
    abstract class AbstractDerived : Base
    {
        protected virtual string AbstractFoo()
        {
            return base.foo();
        }
        protected override string foo()
        {
            return AbstractFoo();
        }
    }
    
    class Derived : AbstractDerived
    {
        protected override string AbstractFoo()
        {
            return "Deprived";
        }
        public new string foo()
        {
            return AbstractFoo();
        }
    }
    
    static class Program
    {
        public static void Main(string[] args)
        {
            var b = new Base();
            var d = new Derived();
            Base derivedAsBase = d;
            Console.Write(nameof(b) + " -> "); b.ExhibitSubclassDependentBehavior(); // "b -> Hi, I am Base and Base."
            Console.WriteLine(nameof(d) + " -> " + d.foo()); // "d -> Deprived"
            Console.Write(nameof(derivedAsBase) + " -> "); derivedAsBase.ExhibitSubclassDependentBehavior(); // "derivedAsBase -> Hi, I am Derived and Deprived."
        }
    }
