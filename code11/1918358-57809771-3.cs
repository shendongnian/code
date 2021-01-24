    static readonly Lazy<HttpClient> httpClient = new Lazy<HttpClient>();
    public async Task DeleteLogs(int[] ids) {
        var queryString = new QueryString(string.Empty);
        foreach (var id in ids) {
            queryString.Add("ids", id.ToString());
        }
    
        var url = _configuration["BaseUrl"] + _configuration["Endpoint"] + "/" + queryString.ToString();
    
        var response = await httpClient.Value.DeleteAsync(url);
        response.EnsureSuccessStatusCode();        
    }
