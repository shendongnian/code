        static async Task DoSomeThingAsync(string name)
        {
            Console.WriteLine($"{name} is starting on thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine($"{name} is now on thread {Thread.CurrentThread.ManagedThreadId}");
            }
        }
        static async Task Main(string[] args)
        {
            var task1 = DoSomeThingAsync("Harry");
            var task2 = DoSomeThingAsync("Fred");
            var task3 = DoSomeThingAsync("Jack");
            Task[] MyTasks = new Task[3]{ task1, task2, task3 };
            await Task.WhenAll(MyTasks);
            Console.WriteLine("All tasks have completed.");
        }
