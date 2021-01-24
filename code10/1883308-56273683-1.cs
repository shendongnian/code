    public static class IServiceCollectionExtensions {
        public static IServiceCollection AddSingletonConfigurationObject<TService>(
            this IServiceCollection services, 
            IConfiguration configuration,
            string appSettingsKey) where TService: class
        {   
            
            var setting = configuration.GetSection(appSettingsKey).Get<TService>();
            services.AddSingleton(setting);
            return services;
        }
    }
