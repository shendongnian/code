    builder.RegisterAssemblyTypes(...)
        .As(t => t.GetInterfaces()
            .Where(i => i.IsClosedTypeOf(typeof(IEventHandler<>)))
            .Select(i => new KeyedService("handler", i)));
    builder.RegisterGeneric(typeof(MultipleDispatchEventHandler<>))
        .As(typeof(IEventHandler<>))
        .WithParameter(
             (pi, c) => pi.Name == "handlers",
             (pi, c) => c.ResolveService(
                 new KeyedService("handler", pi.ParameterType)));
