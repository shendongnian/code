    using System;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                A objA = new A();
                A objB = new B();
                Console.ReadLine(); // only used to keep the output on-screen
            }
        }
    
        class A
        {
            public A()
            {
                Console.WriteLine("method of A class");
            }
        }
    
        class B : A
        {
            public B()
            {
                Console.WriteLine("method of B class");
            }
        }
    }
