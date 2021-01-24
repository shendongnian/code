    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<AuthHeaderHandler>();
        services.AddHttpClient<BaseClient>(client =>
         {
             //code omitted for brevity
             ...
         })
          .AddHttpMessageHandler<AuthHeaderHandler>();
     }
