    using System;
    using System.Runtime.CompilerServices;
    
    [AttributeUsageAttribute(AttributeTargets.All)]
    class FooAttribute : Attribute
    {
    }
    
    [Foo]
    class Bar
    {
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var attr = typeof(Bar).GetCustomAttributes(typeof(FooAttribute), true)[0];
            var attr2 = typeof(Bar).GetCustomAttributes(typeof(FooAttribute), true)[0];
            Console.WriteLine(attr == attr2); // Prints False
        }
    }
