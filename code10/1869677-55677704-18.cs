    using System;
    using System.Reflection;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(new Derived().myString);
            }
        }
    
        public static class TraceHelper
        {
            public static void Trace(string message)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Trace: {message}.");
                Console.ForegroundColor = color;
            }
        }
    
        public class Base
        {
            public string myString;
    
            public Base(string str)
            {
                TraceHelper.Trace("Base constructor called");
    
                myString = myString ?? "Hi";
                myString += str;
            }
        }
    
        public class Derived : Base
        {
            private static readonly ConstructorInfo baseCtor = typeof(Base).GetConstructor(new[] { typeof(string) });
    
            public Derived() : base(null)
            {
                TraceHelper.Trace("Derived constructor called");
    
                base.myString = "Hello";
                @base(" world");
            }
    
            private void @base(string str)
            {
                baseCtor.Invoke(this, new[] { str });
            }
        }
    }
