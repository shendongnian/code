    Task[] tasks = new Task[3]
    {
        Task.Factory.StartNew(() => MethodA()),
        Task.Factory.StartNew(() => MethodB()),
        Task.Factory.StartNew(() => MethodC())
    };
    
    //Block until all tasks complete.
    Task.WaitAll(tasks);
