    services.AddHttpClient("MyAutoRestClient", c =>
    {
        // configure your HttpClient instance
    });
    services.AddScoped<MyAutoRestClient>(p =>
    {
        var httpClient = p.GetRequiredService<IHttpClientFactory>().GetClient("MyAutoRestClient");
        // get or create any other dependencies
        // set disposeHttpClient to false, since it's owned by the service collection
        return new MyAutoRestClient(credentials, httpClient, false);
    });
