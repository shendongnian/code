    public Task<string> GetElidingKeywordsAsync(string url)
    {
        HttpClient client;
        using (client = new HttpClient());  // gets disposed before next statement
            return client.GetStringAsync(url);  // don't be fooled by the indent
    }
