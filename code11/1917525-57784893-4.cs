    namespace AutoFacFunctionAppPrototype.Builders
    {
        public class AutoFacServiceProviderBuilder : IServiceProviderBuilder
        {
            private readonly IConfiguration configuration;
    
            public AutoFacServiceProviderBuilder(IConfiguration configuration) 
                => this.configuration = configuration;
    
            public IServiceProvider Build()
            {
                var services = new ServiceCollection();
                services.AddTransient<ITransientService, TransientService>();
                services.AddScoped<IScopedService, ScopedService>();
    
                var builder = new ContainerBuilder();
    
                builder.RegisterType<SingletonService>().As<ISingletonService>().SingleInstance();
    
                builder.Populate(services); // Populate is needed to have support for scopes.
                return new AutofacServiceProvider(builder.Build());
            }
        }
    }
