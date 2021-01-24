    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMyStuff(this IServiceCollection services, string someParam, string someOtherParam)
        {
            // do stuff
            return services;
        }
    }
