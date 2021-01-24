    public void ConfigureServices(IServiceCollection services) {
        //... normal registration here
        // Add services to the collection. Don't build or return
        // any IServiceProvider or the ConfigureContainer method
        // won't get called.
    }
    public void ConfigureContainer(ContainerBuilder builder) {
        //configure auto fac here
        builder.RegisterModule(new ContainerModule(Configuration));
    }
