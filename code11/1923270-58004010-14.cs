    public Task<string> GetElidingKeywordsAsync(string url)
    {
        HttpClient client;
        using (client = new HttpClient())
        {
        }
        return client.GetStringAsync(url);
    }
