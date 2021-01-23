    var container = new UnityContainer();
    container.RegisterType<IRepository1, ConcreteRepository1>();
    container.RegisterType<IRepository2, ConcreteRepository2>();
    container.RegisterType<IRepository3, ConcreteRepository3>();
    
    var controller = container.Resolve<Controller1>();
