    public static class AutoMapperFactory
    {
        public static IConfigurationProvider CreateMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Scan *.UI assembly for AutoMapper Profiles
                var assembly = Assembly.GetAssembly(typeof(AutoMapperFactory));
    
                cfg.AddMaps(assembly);
    
                cfg.IgnoreAllUnmapped();
            });
    
            return config;
        }
    }
