    public static IServiceCollection AddDotaClientService(this IServiceCollection services)
        {
            services.AddTransient<IRestClient>(provider =>
            {
                var clientFactory = provider.GetService<IRestClientFactory>();
                return clientFactory.Create();
            });
    
            services.AddSingleton<IRestClientFactory, RestClientFactory>();
    
            return services;
        }
