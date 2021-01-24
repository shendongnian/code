    var tasks = new Task[3];
    var rnd = new Random();
    for (int ctr = 0; ctr <= 2; ctr++)
        tasks[ctr] = Task.Run(() => Thread.Sleep(rnd.Next(500, 3000)));
    
    try
    {
        int index = Task.WaitAny(tasks);
        Console.WriteLine("Task #{0} completed first.\n", (index + 1));
        Console.WriteLine("Status of all tasks:");
        for (int i = 0; i <= 2; i++)
            Console.WriteLine("   Task #{0}: {1}", (i + 1), tasks[i].Status);
    }
    catch (AggregateException)
    {
        Console.WriteLine("An exception occurred.");
    }
