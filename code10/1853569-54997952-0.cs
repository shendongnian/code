    // Added string id as parameter
    public async Task<List<T>> GetAsync(string id)
    {
        // webUrl now become the same as WebServiceUrl but with parameter added
        string webUrl = "http://localhost:57645/api/BlogContents/?id=" + id; 
        var httpClient = new HttpClient();
        var json = await httpClient.GetStringAsync(webUrl);
        var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
    
        return taskModels;
    }
