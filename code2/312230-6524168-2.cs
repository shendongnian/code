    Task[] tasks = new Task[3]
    {
        Task.Factory.StartNew(() => MethodA()),
        Task.Factory.StartNew(() => MethodB()),
        Task.Factory.StartNew(() => MethodC())
    };
    
    //This will not block.
    Task.Factory.ContinueWhenAll(tasks, completedTasks => { RunSomeMethod(); });
