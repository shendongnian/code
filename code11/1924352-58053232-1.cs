    class Program
    {
        static void Main(string[] args)
        {
            int[] Arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int maxConcurrency = 5;
            List<Task> tasks = new List<Task>();
    
            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(0, maxConcurrency))
            {
                // Create a Task object for each element in the array
                foreach (var x in Arr)
                {
    
                    tasks.Add(Task.Run(() =>
                    {
                        // Block until the task can enter a semaphore
                        concurrencySemaphore.Wait();
    
                        // Do some work
                        print(x);
    
                        // Signal you are done with the semaphore
                        concurrencySemaphore.Release();
                    }
                    ));
            }
    
            // Wait a haft a second to allow all tasks to start and block.
            Thread.Sleep(500);
    
            // This will release "maxConcurrency" tasks to be process at a given time.
            concurrencySemaphore.Release(maxConcurrency);
    
            // Main thread waits for all tasks to complete.
            Task.WaitAll(tasks.ToArray());
        }
    
        Console.WriteLine("Press any key to exit program...."); Console.ReadKey();
        } /* end Main */
    
        static void print(int x)
        {
            Console.WriteLine("Hello World! {0}", x);
            Thread.Sleep(3000);  //Wait 3 seconds to allow other Task to process before exiting
        }
    } /* end class */
