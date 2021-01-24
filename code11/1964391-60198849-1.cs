    public IServiceProvider ConfigureServices(IServiceCollection services) {
         services.AddMiniProfiler(options => {
             options.IgnoredPaths.Add("/js/");
             options.IgnoredPaths.Add("/css/");
         })
    }
