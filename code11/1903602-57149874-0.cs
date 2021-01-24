    using First;
    using Second;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication16
    {
        class Program
        {
            static void Main(string[] args)
            {
                FirstClass fc = new FirstClass();
                fc.DisplayHello();
                SecondClass sc = new SecondClass();
                sc.DisplayHello();
            }
        }
    }
    
    namespace First
    {
        internal class FirstClass
        {
            public void DisplayHello()
            {
                Console.WriteLine("Hello this is The FIRST Class.");
            }
        }
    }
    
    namespace Second
    {
        internal class SecondClass
        {
            public void DisplayHello()
            {
                Console.WriteLine("Hello this is The SECOND Class.");
            }
        }
    }
