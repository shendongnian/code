    IKernel kernel = new StandardKernel();
    // register implementor of IConfiguration
    kernel.Bind<IConfiguration>().To<Config>();
    // register AppConfig as a singleton
    kernel.Bind<AppConfig>().ToSelf().InSingletonScope();
    
    ...
    
    // get the AppConfig singleton
    var appConfig = kernel.Get<AppConfig>();
