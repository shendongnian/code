    public Task<string> GetElidingKeywordsAsync(string url)
    {
        using var client = new HttpClient();
        return client.GetStringAsync(url);
    }
