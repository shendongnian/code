    using Microsoft.Extensions.DependencyInjection;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
    }
