    private async Task<string> GetToken()
    {
        var client = new HttpClient();
        
        // removed code for clarity
        var response = client.SendAsync(httpRequestMessage).Result;
        var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
        var token = payload.Value<string>("access_token");
        return Task.FromResult(token);
    }
