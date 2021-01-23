    IWindsorContainer container = new WindsorContainer();
    // Register repositories
    _container.Register(
            AllTypes.Pick()
                    .FromAssemblyNamed("MyDataLayerAssembly")
                    .WithService
                    .DefaultInterface());
    // Register services
    _container.Register(
            AllTypes.Pick()
                    .FromAssemblyNamed(typeof(ISomeService).Assembly.GetName().Name)
                    .WithService
                    .DefaultInterface());
    ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
