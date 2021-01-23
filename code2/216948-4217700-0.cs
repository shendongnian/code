    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main()
        {
            Task t1 = Task.Factory.StartNew(() => Thread.Sleep(1000));
            Task t2 = Task.Factory.StartNew(() => {
                Thread.Sleep(500);
                throw new Exception("Oops");
            });
            
            try
            {
                Task.WaitAll(t1, t2);
                Console.WriteLine("All done");
            }
            catch (AggregateException)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
