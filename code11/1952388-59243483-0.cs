    public async Task<string> GetIpRequestHelperAsync(string url)
    {
      using (var cl = new HttpClient())
        return await cl.GetStringAsync(url);
    }
