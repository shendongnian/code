    List<TResult> results = new List<TResults>();
    List<Func<T, TResult>> tasks = PopulateTasks();
    
    ManualResetEvent waitHandle = new ManualResetEvent(false);
    void RunTasks()
    {
        foreach(var task in tasks)
            ThreadPool.QueueUserWorkItem(RunTask(task))
        waitHandle.WaitOne();
    
        Console.WriteLine("All tasks completed and results populated");
    }
    
    private readonly object listLock = new object();
    void RunTask(Func<T, TResult> task)
    {
        var result = task(...);
        lock (listLock )
        {
           results.add(result);
           if (results.Count == tasks.Count)
              waitHandle.reset();
        }
    }
