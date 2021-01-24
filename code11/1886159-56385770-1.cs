    public IConfigurationRoot Configuration { get; private set; }
    public void ConfigureServices(IServiceCollection services) {
        services
            .AddCustomOptions(Configuration)
            .AddCors()
            .AddJwtAuthentication()
            .AddHttpClients()
            .AddCustomMVC()
            .AddIIS()
            .AddCaching()
            .AddCustomDbContext(Configuration, Environment)
            .AddSwagger()
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddHealthChecksUI();    
    }
    public void ConfigureContainer(ContainerBuilder builder) {
       var connectionString = Configuration.GetConnectionString(nameof(FirstResponseContext));
         
        // Use and configure Autofac
        builder.RegisterModule(new MediatorModule());
        builder.RegisterModule(new ApplicationModule(connectionString));
    }
