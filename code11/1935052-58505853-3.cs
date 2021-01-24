    private static MapperConfiguration GetMappingConfiguration()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<DateTime>().As<IDateTime>();
    
        var assembly = Assembly.GetExecutingAssembly();
        var loadedProfiles = assembly.ExportedTypes
            .Where(type => type.IsSubclassOf(typeof(Profile)))
            .ToArray();
    
        containerBuilder.RegisterTypes(loadedProfiles);
    
        var container = containerBuilder.Build();
    
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ConstructServicesUsing(container.Resolve);
    
            foreach (var profile in loadedProfiles)
            {
                var resolvedProfile = container.Resolve(profile) as Profile;
                cfg.AddProfile(resolvedProfile);
            }
        });
    
        return config;
    }
