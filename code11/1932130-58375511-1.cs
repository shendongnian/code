    /// <summary>
    /// Adds a non distributed in memory implementation of <see cref="IMemoryCache"/> to the
    /// <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddMemoryCache(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        services.AddOptions();
        services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
        return services;
    }
