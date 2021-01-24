    public async Task DoMagicStuff()
    {       
        var task1 = DoDbAsync(); // Start Task
        var task2 = DoWebAsync();// Start Task
    
        // wait for both
        await Task.WhenAll(task1,task2);
    }
