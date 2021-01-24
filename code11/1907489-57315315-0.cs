    public async Task<IEnumerable<Apps.Resource>> getApps()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "apps");
        var response = await _client_SB.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Get apps collection with pagination
        Apps.RootObject model = JsonConvert.DeserializeObject<Apps.RootObject>(json);
        // Return only apps
        return model.resources;
    }
    
