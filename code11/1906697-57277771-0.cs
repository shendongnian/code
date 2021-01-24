    public static class CommonServicesExtension
    {
        public static IServiceCollection AddCommonServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddNodaDateTime();
            services.AddMemoryCache();
            services.AddCurrencyExchange();
            // Add and configure many things
            return services;
        }
    }
