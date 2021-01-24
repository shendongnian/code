    //To start with, create a named client:
    services.AddHttpClient("GitHubClient", ctx => { ctx.BaseAddress = new Uri("https://api.github.com/"); });
    //Then set up DI for the TypedClient
    services.AddSingleton<IGitHubService>(ctx =>
    {
        var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
        var httpClient = clientFactory.CreateClient("GitHubClient");
     
        return new GitHubService(httpClient, repositoryName);
    });
      
