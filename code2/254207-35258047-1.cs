    public Task<int> BlahAsync()
    {
        // ...
    }
    int result = BlahAsync().GetAwaiter().GetResult();
