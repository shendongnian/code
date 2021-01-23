    var container = new UnityContainer();
    // Register the catalog - this handles MEF integration.
    container.RegisterCatalog(new DirectoryCatalog("."));
    // Register our Unity components.
    container.RegisterType<IUnityComponent, UnityComponent>(new ContainerControlledLifetimeManager());
