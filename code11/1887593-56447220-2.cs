    public static class ServiceCollectionDelegateExtensions
    {
        public static IServiceCollection RegisterDelegateFromService<TService, TDelegate>(
            this IServiceCollection serviceCollection,
            Func<TService, TDelegate> getDelegateFromService)
            where TDelegate : class
        {
            return serviceCollection.AddTransient(serviceProvider =>
                getDelegateFromService(serviceProvider.GetRequiredService<TService>()));
        }
    }
