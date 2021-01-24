    public async Task<string> GetAsync()
    {
        var innerTask = InnerGetAsync();
        var result = await innerTask;
        var stringResult = result.ToString();
        return stringResult;
    }
