    var builder = new ContainerBuilder();
    builder.RegisterSource(new Autofac.Features
        .Variance.ContravariantRegistrationSource());
    builder.RegisterAssemblyTypes(typeof(IEventHandler<>).Assembly)
        .AsClosedTypesOf(typeof(IEventHandler<>));
    builder.RegisterGeneric(typeof(EventRaiser<>))
        .As(typeof(IEventRaiser<>));
    var container = builder.Build();
    Assert.AreEqual(0, CustomerMovedEventHandler.handleCount);
    Assert.AreEqual(0, NotifyStaffWhenCustomerMovedEventHandler.handleCount);
    Assert.AreEqual(0, CustomerMovedAbroadEventHandler.handleCount);
    container.Resolve<IEventRaiser<CustomerMovedEvent>>()
        .Raise(new CustomerMovedEvent());
    Assert.AreEqual(1, CustomerMovedEventHandler.handleCount);
    Assert.AreEqual(1, NotifyStaffWhenCustomerMovedEventHandler.handleCount);
    Assert.AreEqual(0, CustomerMovedAbroadEventHandler.handleCount);
    container.Resolve<IEventRaiser<CustomerMovedAbroadEvent>>()
        .Raise(new CustomerMovedAbroadEvent());
    Assert.AreEqual(2, CustomerMovedEventHandler.handleCount);
    Assert.AreEqual(2, NotifyStaffWhenCustomerMovedEventHandler.handleCount);
    Assert.AreEqual(1, CustomerMovedAbroadEventHandler.handleCount);
    container.Resolve<IEventRaiser<SpecialCustomerMovedEvent>>()
        .Raise(new SpecialCustomerMovedEvent());
    Assert.AreEqual(3, CustomerMovedEventHandler.handleCount);
    Assert.AreEqual(3, NotifyStaffWhenCustomerMovedEventHandler.handleCount);
    Assert.AreEqual(1, CustomerMovedAbroadEventHandler.handleCount);
