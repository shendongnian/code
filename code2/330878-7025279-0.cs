    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Class1 c = new Class1();
                c.Test(); // call the raw method but with a compiler warning
            }
        }
    }
