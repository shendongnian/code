    Task task1 = Task.Factory.StartNew(() => { throw new ArgumentException(); } );
    Task task2 = Task.Factory.StartNew(() => { throw new UnauthorizedAccessException(); } );
    
    try
    {
        Task.WaitAll(task1, task2);
    }
    catch (AggregateException ae)
    {
    }
