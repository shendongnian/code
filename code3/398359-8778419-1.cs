    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Task.Factory.StartNew(Do);
                Console.ReadKey();
            }
    
            static void Do()
            {
                Console.WriteLine("Hello from a thread");
            }
        }
    }
