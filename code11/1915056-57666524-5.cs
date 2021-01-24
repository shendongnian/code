    public void ConfigureServices(IServiceCollection services) {
        services.AddScoped<ConcreteA>();
        services.AddScoped<ConcreteB>();  
        //...
    }
    
    public void Configure(IApplicationBuilder app) {
        app.UseStatusCodePages();
        app.UseDeveloperExceptionPage();
        app.UseMvcWithDefaultRoute();
        // Create a new IServiceScope that can be used to resolve scoped services.
        using(var scope = app.ApplicationServices.CreateScope()) {            
            ConcreteA A = scope.ServiceProvider.GetRequiredService<ConcreteA>();
            A.Run();
            //ConcreteA instance and injected ConcreteB are in same scope
        }
        //both will be properly disposed of here when they both got out of scope.
    }
