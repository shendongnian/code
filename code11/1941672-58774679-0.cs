    public async Task<bool> SupportsTls12(string url)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        var client = new HttpClient();
        try
        {
            var response = await client.GetAsync(url);
            return true;
        }
        catch(HttpRequestException)
        {
            return false;
        }
    }
