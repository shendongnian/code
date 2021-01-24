    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Use whichever provider you have here, this is where you grab a connection string from the app configuration.
        services.AddDbContext<ShopContext>(options =>
            options.UseInMemoryDatabase("Initrode"));
        services.AddScoped<CartService>();
        services.AddScoped<OrderService>();
    }
