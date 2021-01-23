    List<TResult> results = new List<TResults>();
    List<Func<T, TResult>> tasks = PopulateTasks();
    
    ManualResetEvent waitHandle = new ManualResetEvent(false);
    void RunTasks()
    {
        int i = 0;
        foreach(var task in tasks)
        {
            int captured = i++;
            ThreadPool.QueueUserWorkItem(state => RunTask(task, captured))
        }
        waitHandle.WaitOne();
    
        Console.WriteLine("All tasks completed and results populated");
    }
    
    private int counter;
    private readonly object listLock = new object();
    void RunTask(Func<T, TResult> task, int index)
    {
        var res = task(...); //You haven't specified where the parameter comes from
        lock (listLock )
        {
           results[index] = res;
        }
        if (InterLocked.Increment(ref counter) == tasks.Count)
            waitHandle.Set();
    }
