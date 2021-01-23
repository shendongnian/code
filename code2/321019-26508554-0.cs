    // set up your task
    Action<int> job = (int i) =>
    {
        if (i % 100 == 0)
            throw new TimeoutException("i = " + i);
    };
    // we want many tasks to run in paralell
    var tasks = new Task[1000];
    for (var i = 0; i < 1000; i++)
    {
        // assign to other variable,
        // or it will use the same number for every task
        var j = i; 
        // run your task
        var task = Task.Run(() => job(j));
        // save it
        tasks[i] = task;
    }
    try
    {
        // wait for all the tasks to finish in a blocking manner
        Task.WaitAll(tasks);
    }
    catch (AggregateException e)
    {
        // catch whatever was thrown
        foreach (Exception ex in e.InnerExceptions)
            Console.WriteLine(ex.Message);
    }
