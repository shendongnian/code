    private static void DoWork()
        {
            TestForm form = new TestForm();
            Task formTask = Task.Run(() => form.ShowDialog());
            Task<string> testTask = Task.Run(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(i.ToString());
                }
                
                Console.WriteLine("Background task finished");
                return "Plop";
            });
            Console.WriteLine("Waiting for background task");
            testTask.Wait();
            if (testTask.Result == "Plop")
            {
                Dispatcher.CurrentDispatcher.InvokeAsync(() => form.Close());
            }
            Console.WriteLine("App finished");
        }
