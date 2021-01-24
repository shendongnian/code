    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProject2(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            var dbSettings = configuration.GetSection("Settings");
            services.Configure<DbSettings>(dbSettings);
            return services;
        }
    }
