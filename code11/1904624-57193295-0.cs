    services.AddHttpClient("myServiceClient")
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(uri);
            client.Timeout = TimeSpan.FromSeconds(5);
        })
        .ConfigurePrimaryHttpMessageHandler(
            handler => new HttpClientHandler() { CookieContainer = new CookieContainer() }
        );
		
