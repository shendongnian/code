    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Base b = new Child();
                Console.WriteLine(b.I);
                Console.Read();
            }
        }
    
        class Base
        {
            public int I { get; protected set; }
    
            public Base()
            {
                I = 42;
            }
        }
    
        class Child : Base
        {
            public Child()
            {
                I = 43;
            }
        }
    }
