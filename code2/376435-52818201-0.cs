    using System;
    class A
    {
        ~A() => Console.WriteLine("~A");       
    }
    class B : A
    {
        ~B() => Console.WriteLine("~B");
    }
    public class Program
    {
        public static void Main() => new B();        
    }
