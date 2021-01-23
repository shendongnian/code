    namespace ConsoleApplication1
    {
        using System;
        using System.Threading;
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting");
                ThreadPool.QueueUserWorkItem(
                    cb =>
                        {
                            int i = 1;
                            while (true)
                            {
                                Console.WriteLine("Background {0}", i++);
                                Thread.Sleep(1000);
                            }
                        });
                Console.WriteLine("Blocking");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }
    }
