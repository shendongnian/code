    async Task Main()
    {
        var hasValue = false;
        var asyncEnumerator = GetValuesAsync().GetAsyncEnumerator();
        do
        {
            var task = asyncEnumerator.MoveNextAsync();
            Console.WriteLine($"Completed synchronously: {task.IsCompleted}");
            hasValue = await task;
            if (hasValue)
            {
                Console.WriteLine($"Value={asyncEnumerator.Current}");
            }
        }
        while (hasValue);
        await asyncEnumerator.DisposeAsync();
    }
    
    async IAsyncEnumerable<int> GetValuesAsync()
    {
        foreach (var batch in GetValuesBatch())
        {
            await Task.Delay(1000);
            foreach (var value in batch)
            {
                yield return value;
            }
        }
    }
    IEnumerable<IEnumerable<int>> GetValuesBatch()
    {
        yield return Enumerable.Range(0, 3);
        yield return Enumerable.Range(3, 3);
        yield return Enumerable.Range(6, 3);
    }
