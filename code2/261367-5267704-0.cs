    IUnityContainer container = ...;
    
    container.RegisterInstance<Func<int, ReadOnlyCollection<Entity1>>(e => new Entity1().GetAll()));
    container.RegisterType<Class1>();
    
    var instance = container.Resolve<Class1>();
