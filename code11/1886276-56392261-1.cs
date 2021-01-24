    List<Task> nonAwaitedTasks = new List<Task>();
    var TestA()
    {
        // start a Task, for some reason you don't want to await for it:
        Task taskA = DoSomethingAsync(...);
        // perform your test
        // finish without awaiting for taskA. Make sure it will be awaited before the
        // class is disposed:
        nonAwaitedTasks.Add(taskA);
    }
    public void Dispose()
    {
        Dispose(true);
    }
    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
            // wait for all tasks to complete
            Task.WaitAll(this.nonAwaitedTasks);
        }
    }
    }
        
