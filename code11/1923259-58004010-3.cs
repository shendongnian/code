    public Task<string> GetElidingKeywordsAsync(string url)
    {
        using (var client = new HttpClient());  // gets disposed before next statement
            return client.GetStringAsync(url);  // don't be fooled by the indent
    }
