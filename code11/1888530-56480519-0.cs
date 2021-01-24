    var builder = new ContainerBuilder();
    // register the class that provides the method and its dependencies.
    builder.RegisterType<OrderValidator>();
    builder.RegisterType<SomeDependency>().As<ISomeDependency>();
   
    // register the delegate using a factory method that resolves 
    // the type that provides the method and then returns the method.
    builder.Register<ValidateAddressFunction>(context =>
    {
        var validator = context.Resolve<OrderValidator>();
        return validator.ValidateAddress;
    });
