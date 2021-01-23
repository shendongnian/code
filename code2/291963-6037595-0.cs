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
                Console.WriteLine(b.i);
                Console.Read();
            }
        }
    
        class Base
        {
            public readonly int i;
    
            public Base()
            {
                i = 42;
            }
    
            protected Base(int newI)
            {
                i = newI;
            }
        }
    
        class Child : Base
        {
            public Child()
                : base(43)
            {}
        }
    }
