    public async Task HitEndPointsAsync()
    {
        var tasks = new List<Task>();
        for (int i = 0; i < _urls.Length; i++)
        {
            tasks.Add(new Task(async () => await HitEndPointsAsync(i)));
        }
        await Task.WhenAll(tasks);
    }
