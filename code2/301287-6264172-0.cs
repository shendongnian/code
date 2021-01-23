    var cb = new ContainerBuilder();
    cb.Register(c => new SomeImpl1()).Named<ISomeInterface>("impl1");
    cb.Register(c => new SomeImpl2()).Named<ISomeInterface>("impl2");
    cb.Register(c => new Service1(c.ResolveNamed<ISomeInterface>("impl1"))).As<IService1>();
    cb.Register(c => new Service2(c.ResolveNamed<ISomeInterface>("impl2"))).As<IService2>();
    var container = cb.Build();
    
    var s1 = container.Resolve<IService1>();//Contains impl1
    var s2 = container.Resolve<IService2>();//Contains impl2
