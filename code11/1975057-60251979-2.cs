    public async Task HitEndPointsAsync()
    {
        var tasks = new List<Task>();
        for (int i = 0; i < _urls.Length; i++)
        {
            tasks.Add(Task.Run(async () => await HitEndPointsAsync(i)));
        }
        await Task.WhenAll(tasks);
    }
