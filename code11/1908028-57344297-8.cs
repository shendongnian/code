    public class IocConfig
    {
        public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
        {
             serviceCollection
                .AddDbContext<SomeContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
             serviceCollection.AddScoped<IDepartmentRepository, DepartmentRepository>();
             serviceCollection.AddScoped<IDepartmentAppService, DepartmentAppService>();
             .
             .
             .
    
             return services;
        }
    }
