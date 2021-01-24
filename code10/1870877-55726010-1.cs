    public static IServiceCollection AddMyConfigSettings(this IServiceCollection services, IConfiguration configuration) {
        MyConfigSettings myConfigSettings = configuration.GetSection("MyConfig").Get<MyConfigSettings>();
        services.AddSingleton(myConfigSettings);
        return services;
    }
