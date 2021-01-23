    builder.RegisterAssemblyTypes(typeof(IAggregateRepositoryAssembly).Assembly)
        .As(t => t.GetInterfaces()
                  .Where(i => i.IsClosedTypeOf(typeof(IAggregateViewRepository<>))
                  .Select(i => new KeyedService("view-implementor", i))
                  .Cast<Service>())
        .SingleInstance();
