    public async Task<T> ProcessAsync<T>(HttpRequestMessage request)
    {
        HttpResponseMessage response = await new HttpClient().SendAsync(request);
        T responseModel = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        return responseModel;
    }
    public async Task<T> GetAsync<T>(string uri)
    {
        return await ProcessAsync<T>(new HttpRequestMessage(HttpMethod.Get, uri));
    }
