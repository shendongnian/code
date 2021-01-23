    // Library.cs
    using System;
    
    public class Library
    {
        public static void Foo<T>(T value)
        {
            Console.WriteLine("{0} : {1}", typeof(T), value.GetType());
            if (typeof(T) != value.GetType())
            {
                dynamic d = value;
                Foo(d);
            }
        }
    }
    // Test.cs
    class Internal {}
    class Program
    {
        static void Main(string[] args)  
        {
            Library.Foo<object>(new Internal());
        }
    }
