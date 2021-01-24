    services.AddOpenApiDocument(document => 
    {
        document.DocumentName = "v1";
        document.PostProcess = d =>
        {
            d.Info.Version = "v1";
            d.Info.Title = "Main API v1.0";
        };
        document.AddSecurity("apikey", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Type = OpenApiSecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = OpenApiSecurityApiKeyLocation.Header
        });
    
        document.OperationProcessors.Add(
            new OperationSecurityScopeProcessor("bearer"));
    });
