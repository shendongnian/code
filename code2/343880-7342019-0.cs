    public static void Main()
    {
        var scheduler = new LimitedConcurrencyLevelTaskScheduler(5);
        TaskFactory factory = new TaskFactory(scheduler);
        for (int i = 0; i < 50; i++)
        {
            int idx = i;
            var newTask = factory.StartNew(() =>
                {
                    Console.WriteLine("Starting " + idx);
                    Thread.Sleep(5000);
                });
        }
        Console.ReadLine();
    }
