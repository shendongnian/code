    List<Task> tasks = new List<Task>() ;
    for (int i = 0; i < loopCounter; i++)
    {
        Task t = new Task(() => SumRootN(10));
        t.Start();
        tasks.Add(t);
    }
    Task.WaitAll(tasks.ToArray()); 
