    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<BaseClient>(client =>
        {
            client.BaseAddress = new Uri("yrl");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
        });
     }
