    public async Task<T> GetObjectFromEndpoint<T>(string url, params string[] args)
        where T : class
    {
        var uri = new Uri(string.Format(url, args));
        var response = await _client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }
        return default(T);
    }
