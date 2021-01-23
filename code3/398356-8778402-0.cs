    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static void Main(string[] args)
            {
                Task.Factory.StartNew(Do);
                Console.Read();
            }
    
            private static void Do()
            {
                Console.WriteLine("Hello from a thread");
            }
        }
    }
