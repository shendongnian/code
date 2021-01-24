    public void ConfigureServices(IServiceCollection services)
    {
       services.AddScoped<HMACAuthenticationAttribute>();
       services.AddSingleton<IUserService, UserService>();
    }
