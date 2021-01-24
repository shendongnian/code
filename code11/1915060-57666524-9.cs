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
            // resolve the services within this scope
            ConcreteA A = scope.ServiceProvider.GetRequiredService<ConcreteA>();
            //ConcreteA instance and injected ConcreteB are used in the same scope
            //do something
            A.Run();           
        }
        //both will be properly disposed of here when they both got out of scope.
    }
