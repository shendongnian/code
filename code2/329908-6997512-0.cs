    var tasks = new List<Task>();
    for (int i = 0; i < 10; ++i)
    {
        tasks.Add(task.ContinueWith(_=> increment()));
    }
    Task.WaitAll(tasks.ToArray());
