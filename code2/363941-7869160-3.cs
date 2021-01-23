    ModelBinderProviders.BinderProviders.Add(new YourModelBinderProvider());
    var builder = new ContainerBuilder();            
    builder.RegisterModelBinderProvider();
    builder.RegisterType<ConcreteObject>().As<IObject>();    
    var container = builder.Build();
    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
