    public async Task<IEnumerable<MyModel>[]> GetDataAsync()
    {
        Task[] tasks = new Task[3];
        tasks[0] = staticDataService.Method1Async();
        tasks[1] = staticDataServiceMethod2Async();
        tasks[2] = staticDataServiceMethod2Async();
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
