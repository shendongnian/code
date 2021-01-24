    public async Task FetchProjects(params string[] projects)
    {
        var tasks = new List<Task<bool>>();
        foreach (var project in projects)
        {
            // Calling the api, but not awaiting the call just yet.
            tasks.Add(FetchProjectInfo(project));
        }
    
        // awaiting all api calls here.
        await Task.WhenAll(tasks);
        // You might want to check whether all calls returned true here.
    }
    
    // This would be your existing method.
    private async Task<bool> FetchProjectInfo(string project)
    {
        string url = CreateUrl(project);
        
        // TODO: Include error handling 
        // (and perhaps share the HttpClient between calls)
        using (var client = new HttpClient())
        using (var response = await client.GetAsync(url))
        {
            // TODO: Do something with response.
        }
    }
