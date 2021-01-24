    public void ConfigureServices(IServiceCollection services)
    {
        // ... Other Configurations 
    
        services.AddOData();
        services.AddTransient<MyModelBuilder>();
    
        // ... MVC Service Configurations 
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, MyModelBuilder modelBuilder)
    {
        // ... Other Configurations
    
        app.UseMvc(routeBuilder =>
        {
            routeBuilder.MapODataServiceRoute("ODataRoutes", "odata", modelBuilder.GetEdmModel(app.ApplicationServices));
        });
    }
