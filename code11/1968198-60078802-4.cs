    public static class FunctionHostBuilderExtensions {
        /// <summary>
        /// Set up the configuration for the builder itself. This replaces the 
        /// currently registered configuration with additional custom configuration.
        /// This can be called multiple times and the results will be additive.
        /// </summary>
        public static IFunctionsHostBuilder ConfigureHostConfiguration (
            this IFunctionsHostBuilder builder, 
            Action<IServiceProvider, IConfigurationBuilder> configureDelegate) {
            IServiceCollection services = builder.Services;            
            var providers = new List<IConfigurationProvider>();            
            //Cache all current configuration provider
            foreach (var descriptor in services.Where(d => d.ServiceType == typeof(IConfiguration)).ToList()) {
                var existingConfiguration = descriptor.ImplementationInstance as IConfigurationRoot;
                if (existingConfiguration is null) {
                    continue;
                }
                providers.AddRange(existingConfiguration.Providers);
                services.Remove(descriptor);
            }
            //add new configuration based on original and newly added configuration
            services.AddSingleton<IConfiguration>(sp => {
                var configurationBuilder = new ConfigurationBuilder();                    
                //call custom configuration
                configureDelegate?.Invoke(sp, configurationBuilder);                
                providers.AddRange(configurationBuilder.Build().Providers);                
                return new ConfigurationRoot(providers);
            });            
            return builder;
        }
    }
