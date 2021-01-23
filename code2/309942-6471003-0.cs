    class Program
        {
            private static SemaphoreSlim threadsSemaphore = new SemaphoreSlim(5, 5);
    
            static void Main(string[] args)
            {
                Timer timer = new Timer(DoSomeWork, null, 0, 100);
    
                Console.ReadKey();
            }
    
            private static void DoSomeWork(object state)
            {
                if (threadsSemaphore.Wait(TimeSpan.FromSeconds(1)))
                {
                    try
                    {
                        Console.WriteLine("Doing work ...");
                        Thread.Sleep(1000);
                    }
                    finally
                    {
                        threadsSemaphore.Release();
                    }
                }
                else
                {
                    Console.WriteLine("Skipping work", threadsSemaphore.CurrentCount);
                }
    
    
            }
        }
