    public static MySDKServiceCollectionExtensions {
        public static IServiceCollection AddMySDK(this IServiceCollection services) {
            services.AddScoped<IScopedService, ScopedService>();
            services.AddSingleton<ISingletonService, SingletonService>();
            //...additional services.
            return services
        }
    }
