    public Task<IEnumerable<MyModel>[]> GetDataAsync()
    {
        Task[] tasks = new Task[3];
        tasks[0] = staticDataService.Method1Async();
        tasks[1] = staticDataService.Method2Async();
        tasks[2] = staticDataService.Method3Async();
        return Task.WhenAll(tasks);
    }
