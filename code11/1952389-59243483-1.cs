    public async Task<string> GetIpGeoLocationAsync(string url)
    {
      using (var cl = new HttpClient())
        return await cl.GetStringAsync(url);
    }
