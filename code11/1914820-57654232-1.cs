    public async Task<string> Post([FromBody]Accounts accounts)
    {
        await ExecuteApiAsync();
        return "Success";
    }
    public async Task ExecuteApiAsync(string mobileNumber)
    {
        // ...
        using (var client = new HttpClient())
        {
            // ...
            await client.GetAsync(url);
        }
    }
