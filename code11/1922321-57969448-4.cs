    var builder = new ContainerBuilder();
    builder.RegisterType<C>().AsImplementedInterfaces().SingleInstance();
    var container = builder.Build();
    var i1 = container.Resolve<I1>();
    var i2 = container.Resolve<I2>();
    Console.WriteLine(i1 == i2);  //true
