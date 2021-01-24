    services.AddHttpClient("my-client", (sp, c) =>
    {
        var opts = sp.GetRequiredService<IOptions<MyOptions>>().Value;
        var uriB = new UriBuilder
        {
            Host = opts.Host,
            Port = opts.Port,
            Scheme = Uri.UriSchemeHttps
        };
        c.BaseAddress = uriB.Uri;
        // Added this line
        c.DefaultRequestHeaders.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);
    });
