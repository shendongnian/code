            Console.WriteLine("Invoking");
            SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);
            this.Actions.Enqueue(delegate
            {
                action();
                Console.WriteLine("Actioned");
                semaphore.Release();
                Console.WriteLine("Released");
            });
            Console.WriteLine("Enqueued");
            Console.WriteLine("Waiting");
            semaphore.Wait();
            Console.WriteLine("Waited");
            semaphore.Dispose();
