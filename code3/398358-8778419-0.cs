    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Task.Factory.StartNew(Do);
            }
    
            private static void Do()
            {
                Console.WriteLine("Hello from a thread");
                Console.ReadKey();
            }
        }
    }
