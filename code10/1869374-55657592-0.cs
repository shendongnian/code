    using System;
    using System.Threading;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Program().Run();
            }
    
            private void Run()
            {
                do
                {
                    while (!Console.KeyAvailable)
                        this.InvokeWithIntervals(1000,
                                                 () => Console.WriteLine("Press any key to continue..."),
                                                 () => Console.Clear());
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
    
            private void InvokeWithIntervals(int interval, params Action[] actions)
            {
                foreach(var action in actions)
                {
                    action.Invoke();
                    Thread.Sleep(interval);
                }
            }
        }
    }
