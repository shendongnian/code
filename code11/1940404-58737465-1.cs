    // Globally defined HTTP client.
    private static readonly HttpClient _httpClient = new HttpClient();
    
    // Other stuff here...
    private async Task SomeFunctionToGetContent()
    {
        var requestTasks = new List<Task<HttpResponseMessage>>();
        var responseTasks = new List<Task>();
        
        for (var i = 0; i < 5; i++)
        {
            // Fake URI but still based on the counter (or other
            // variable, similar to page in the question)
            var uri = new Uri($"https://.../{i}.html");
            requestTasks.Add(_httpClient.GetAsync(uri));
        }
        
        await (Task.WhenAll(requestTasks));
        
        for (var i = 0; i < 5; i++)
        {
            var response = await (requestTasks[i]);
            responseTasks.Add(HandleResponse(response));
        }
        
        await (Tasks.WhenAll(responseTasks));
    }
    
    private async Task HandleResponse(HttpResponseMessage response)
    {
        try
        {
            if (response.Content != null)
            {
                var content = await (response.Content.ReadAsStringAsync());
    
                // do something with content here; check IsSuccessStatusCode to
                // see if the request failed or succeeded
            }
            else
            {
                // Do something when no content
            }
        }
        finally
        {
            response.Dispose();
        }
    }
