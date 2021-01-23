    builder.RegisterAssemblyTypes(...)
        .As(t => t.GetInterfaces()
            .Where(i => i.IsClosedTypeOf(typeof(IEventHandler<>)))
            .Select(i => new KeyedService("handler", i)));
    builder.RegisterGeneric(typeof(MultipleDispatchEventHandler<>))
        .As(typeof(IEventHandler<>))
        .WithParameter(
             (c, pi) => pi.Name == "handlers",
             (c, pi) => c.ResolveService(
                 new KeyedService(pi.ParameterType, "handler")));
