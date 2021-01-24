    public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.AddRegistry(new StructuremapRegistry());
                config.Populate(services);
            });
    
            //Get an instance of ICommonLogService from container
            ICommonLogService CommonLogService = container.GetInstance<ICommonLogService>();
            //Use CommonLogService here
    
            return container.GetInstance<IServiceProvider>();
        }
