    public async Task<uint> AwaitList()
    {
        var list = new List<Task>();
    
        for (var i = 0u; i < 10; i++)
        {
            list.Add(Task.Delay(1));
        }
    
        await Task.WhenAll(list).ConfigureAwait(false);
    
        return 123;
    }
