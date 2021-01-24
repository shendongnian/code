    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext using SQL Server Provider
        services.AddDbContext<PaymentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("myconnectionstring"), x => x.MigrationsAssembly("Payment.Persistence")));
        return services;
    }
