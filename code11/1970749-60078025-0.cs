    public static IServiceCollection AddMyType<T>(this IServiceCollection serviceCollection)
        where T : class, IMyType =>
        serviceCollection
            .AddSingleton<T>();
            .AddSingleton<IMyType>(sp => sp.GetService<T>());
