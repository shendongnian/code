    using System;
    using System.Reflection;
    
    class Foo
    {
        internal Foo()
        {
            Console.WriteLine("Foo constructor");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var ctor = typeof(Foo).GetConstructor
                (BindingFlags.NonPublic |
                 BindingFlags.Public |
                 BindingFlags.Instance,
                 binder: null,
                 types: new Type[0],
                 modifiers: null);
            ctor.Invoke(null);
        }
    }
