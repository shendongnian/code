    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace SomeAsyncStuff
    {
        class Program
        {
            static void Main(string[] args)
            {
                Task.Factory.StartNew(() => { throw new NullReferenceException("ex"); });
            
                // give some time to the task to complete
                Thread.Sleep(3000);
                GC.Collect();
                // GC.WaitForPendingFinalizers();
                Console.WriteLine("completed"); 
            }
        }
    }
