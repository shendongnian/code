    public static void RegisterAllTypes<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.Scan(
            x =>
            {
                x.FromApplicationDependencies()
                    .AddClasses(classes => classes.AssignableTo(typeof(T)))
                        .AsImplementedInterfaces()
                        .WithLifetime(lifetime);
            });
    }
