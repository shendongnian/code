    using System;
    using System.Threading;
    namespace create_thread
    {
        class Program
        {        
            static void Main(string[] args)
            {
                Thread t = new Thread(new ThreadStart(Go));
                t.Start();
                Go();
            }
            static void Go()
            {
                Console.WriteLine("hello");
            }
        }
    }
