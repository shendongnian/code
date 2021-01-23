    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication29
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i = 0;
                object o = (object)i;
                MyMethod(o);
                MyMethod(i); // Doesn't compile.
            }
    
            static void MyMethod<T>(T arg) where T : class
            {
    
            }
        }
    }
