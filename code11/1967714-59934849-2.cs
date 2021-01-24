    public async Task<string> SendGetRequest(string param)
    {
        using (var response = await client.GetAsync(httpLink + param + httpSuffix))
        {
            return await response.Content.ReadAsStringAsync();
        }
    }
