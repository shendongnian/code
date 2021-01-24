    public static IHttpClientBuilder AddMyClient(this IServiceCollection services, string clientName)
    {
        return services.AddHttpClient(clientName, c =>
        {
            ...
        });
    }
