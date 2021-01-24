    public void ConfigureServices(IServiceCollection services)
    {
    ...
        using (var scope = sp.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var appDb = scopedServices.GetRequiredService<MultitenantDbContext>();
    
            appDb.Database.Migrate();
        }
    
    }     
