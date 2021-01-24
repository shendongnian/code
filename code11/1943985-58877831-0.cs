    public void ConfigureServices(IServiceCollection services)
    {
        // This will all go in the ROOT CONTAINER and is NOT TENANT SPECIFIC.
        services.AddMvc();
        services.AddControllers();
        // This adds the required middleware to the ROOT CONTAINER and 
        // is required for multitenancy to work.
        services.AddAutofacMultitenantRequestServices();
    }
