    ...
    var container = builder.Build();
    builder = new ContainerBuilder();
    var components = container.ComponentRegistry.Registrations
                        .Where(cr => cr.Activator.LimitType != typeof(LifetimeScope))
                        .Where(cr => cr.Activator.LimitType != typeof(MyType));
    foreach (var c in components)
    {
        builder.RegisterComponent(c);
    }
    foreach (var source in c.ComponentRegistry.Sources)
    {
        cb.RegisterSource(source);
    }
    container = builder.Build();
