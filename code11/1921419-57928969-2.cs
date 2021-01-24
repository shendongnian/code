    public void Configure(IApplicationBuilder app)
    {
        // ...
    
        // global policy - assign here or on each controller
        app.UseCors("CorsPolicy");
    
        // ...
        
        // IMPORTANT: Make sure UseCors() is called BEFORE this
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
    }
