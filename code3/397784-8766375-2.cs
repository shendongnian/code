    IDbConnectionFactory yellowDbConFactory =
        new YellowDbConnectionFactory();
    IDbConnectionFactory blueDbConFactory =
        new BlueDbConnectionFactory();
    IDbConnectionFactory purpleDbConFactory =
        new PurpleDbConnectionFactory();
    container.Register<IService1>(c =>
        new Service1Impl(yellowDbConFactory,
            c.Resolve<IDep1>());
    container.Register<IService2>(c =>
        new Service2Impl(blueDbConFactory);
    container.Register<IService3>(c =>
        new Service3Impl(purpleDbConFactory, 
            c.Resolve<IDep2>());
