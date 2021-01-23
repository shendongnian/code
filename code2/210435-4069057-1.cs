    List<TResult> results = new List<TResults>();
    List<Func<T, TResult>> tasks = PopulateTasks();
    
    ManualResetEvent waitHandle = new ManualResetEvent(false);
    void RunTasks()
    {
        foreach(var task in tasks)
            ThreadPool.QueueUserWorkItem(state => RunTask(task))
        waitHandle.WaitOne();
    
        Console.WriteLine("All tasks completed and results populated");
    }
    
    private readonly object listLock = new object();
    void RunTask(Func<T, TResult> task)
    {
        var res = task(...); //You haven't specified where the parameter comes from
        lock (listLock )
        {
           results.add(res);
           if (results.Count == tasks.Count)
              waitHandle.reset();
        }
    }
