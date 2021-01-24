    public static IServiceCollection AddSingleton(
        this IServiceCollection services,
        Type serviceType,
        Type implementationType)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        if (serviceType == null)
        {
            throw new ArgumentNullException(nameof(serviceType));
        }
        if (implementationType == null)
        {
            throw new ArgumentNullException(nameof(implementationType));
        }
        return Add(services, serviceType, implementationType, ServiceLifetime.Singleton);
    }
