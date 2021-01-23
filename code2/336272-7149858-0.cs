    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            List<object> stuff = new List<object> { DateTime.Now, true, 666 };
            foreach (object o in stuff)
            {
                dynamic d = o;
                Print(d);
            }
        }
    
        private static void Print(DateTime d)
        {
            Console.WriteLine("I'm a date");
        }
    
        private static void Print(bool b)
        {
            Console.WriteLine("I'm a bool");
        }
    
        private static void Print(int i)
        {
            Console.WriteLine("I'm an int");
        }
    }
