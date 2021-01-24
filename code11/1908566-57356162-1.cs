    public static class ServiceCollectionDataExtensions
    {
        public static void AddDatabase<TDbContext>(this IServiceCollection services, string connectionString)
            where TDbContext : DbContext
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));
            services.AddDbContext<TDbContext>(c => c.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddScoped(provider => new ContextFactory<TDbContext>(() => ActivatorUtilities.CreateInstance<TDbContext>(provider, provider.GetRequiredService<DbContextOptions<TDbContext>>())));
        }
    }
