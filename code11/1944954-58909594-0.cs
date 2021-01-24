    public static IServiceCollection AddSwaggerGen(
        this IServiceCollection services,
        Action<SwaggerGenOptions> setupAction = null)
    {
        // Add Mvc convention to ensure ApiExplorer is enabled for all actions
        services.Configure<MvcOptions>(c =>
            c.Conventions.Add(new SwaggerApplicationConvention()));
        // Register generator and it's dependencies
        services.AddTransient<ISwaggerProvider, SwaggerGenerator>();
        services.AddTransient<ISchemaGenerator, SchemaGenerator>();
        services.AddTransient<IApiModelResolver, JsonApiModelResolver>();
        // Register custom configurators that assign values from SwaggerGenOptions (i.e. high level config)
        // to the service-specific options (i.e. lower-level config)
        services.AddTransient<IConfigureOptions<SwaggerGeneratorOptions>, ConfigureSwaggerGeneratorOptions>();
        services.AddTransient<IConfigureOptions<SchemaGeneratorOptions>, ConfigureSchemaGeneratorOptions>();
        // Used by the <c>dotnet-getdocument</c> tool from the Microsoft.Extensions.ApiDescription.Server package.
        services.TryAddSingleton<IDocumentProvider, DocumentProvider>();
        if (setupAction != null) services.ConfigureSwaggerGen(setupAction);
        return services;
    }
