    services.AddHttpClient("MyClient", c =>
    {
        c.BaseAddress = new Uri("http://interface.net");
        c.DefaultRequestHeaders.Add("Accept", "application/json");
    })
    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
    services.AddHttpClient("MyClient2", c =>
    {
        c.BaseAddress = new Uri("http://interface.net");
        c.DefaultRequestHeaders.Add("Accept", "application/json");
    })
    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(400)));
