    using Microsoft.Extensions.DependencyInjection;
    
         public void ConfigureServices(IServiceCollection services)
                {
                    services.AddControllersWithViews();
        
                    var connectionString = Configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<BloggingContext>(options =>
                        options.UseSqlServer(connectionString), ServiceLifetime.Transient);
        
                }
