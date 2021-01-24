    Action<ContainerBuilder> containerBuilderAction = delegate(ContainerBuilder cb)
    {
        cb.RegisterType<ServiceFoo>().As<IService>();
        cb.RegisterType<ViewModelBase>().PropertiesAutowired(); //The autofac will go to every single property and try to resolve it.
    };
    var mock = AutoMock.GetLoose(actionCB);
            
    var viewModelBase = mock.Create<ViewModelBase>();            
    Assert.IsNotNull(viewModelBase.Service);
