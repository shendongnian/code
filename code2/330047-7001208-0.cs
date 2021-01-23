    IOC.Container.RegisterType<IRepository, GenericRepository>("ModelOne", 
                                new InjectionConstructor(new ModelOneEntities());
    IOC.Container.RegisterType<IRepository, GenericRepository>("ModelTwo", 
                                new InjectionConstructor(new ModelTwoEntities());
 .....
    IRepository modelOneRepository = IOC.Container.Resolve<IRepository>("ModelOne");
