    [ValidateAuthHeader]
    public async Task<IActionResult> GetValues()
    {
        var authHeader = Request.Headers["Authorization"];
    
        _client.SetAuthHeader(authHeader.First());
    
        var response = await _client.GetAsync("api/values");
    
        var contents = await response.Content.ReadAsStringAsync();
    
        return new ContentResult
        {
            Content = contents,
            ContentType = "application/json",
            StatusCode = 200
        };
    }
