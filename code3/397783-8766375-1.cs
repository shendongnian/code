    container.Register<IDbConnectionFactory>("yellow",
        new YellowDbConnectionFactory());
    container.Register<IDbConnectionFactory>("purple",
        new BlueDbConnectionFactory());
    container.Register<IDbConnectionFactory>("purple",
        new PurpleDbConnectionFactory());
    container.Register<IService1>(c =>
        new Service1Impl(
            c.Resolve<IDbConnectionFactory>("yellow"),
            c.Resolve<IDep1>());
    container.Register<IService2>(c =>
        new Service2Impl(
            c.Resolve<IDbConnectionFactory>("blue"));
    container.Register<IService3>(c =>
        new Service3Impl(
            c.Resolve<IDbConnectionFactory>("purple"), 
            c.Resolve<IDep2>());
