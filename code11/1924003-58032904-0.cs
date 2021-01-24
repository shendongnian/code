    public void ConfigureServices(IServiceCollection services) {
    
        services.AddMemoryCache(); //<-- Adding memory cache
    
        services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_xxx);
    
        //...
    }
    
    public void ConfigureContainer(IUnityContainer container) {
       // Could be used to register more types
       UnityConfigurationSection section
            = (UnityConfigurationSection) ConfigurationManager.GetSection ("unity");
        section.Configure (container, "primaryUnityContainer");
    
        var resolver = new UnityDependencyResolver (container);
    
        container.RegisterInstance<IDependencyResolver> (resolver);
    
        DependencyContext.Initialize (resolver);
    }
