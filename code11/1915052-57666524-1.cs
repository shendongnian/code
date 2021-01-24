    public void ConfigureServices(IServiceCollection services) 
    {
       services.AddScoped<ConcreteA>();
       services.AddScoped<ConcreteB>();  
    }
    
    public void Configure(IApplicationBuilder app) {
        app.UseStatusCodePages();
        app.UseDeveloperExceptionPage();
        app.UseMvcWithDefaultRoute();
        using(var scope = app.ApplicationServices.CreateScope()) {
            ConcreteA A = scope.ServiceProvider.GetRequiredService<ConcreteA>();
            A.Run();
        }
    }
