    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<NavaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LATAMConnectionString")));
        services.AddDbContext<StackContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EUConnectionString")));
    
        // Autofac
        var builder = new ContainerBuilder();
    
        // needed only if you plan to inject ICollection<BaseContext>
        builder.RegisterType<NavaContext>().As<BaseContext>();
        builder.RegisterType<StackContext>().As<BaseContext>();
    
        builder.Populate(services);
    
    
        return new AutofacServiceProvider(builder.Build());
    }
