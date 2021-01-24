    public static class AppExtensions
    {
        public static IServiceCollection SetUpAppDependencies(this IServiceCollection serviceCollection,
            string connectionString)
        {
            serviceCollection.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));
            return serviceCollection;
        }
    }
