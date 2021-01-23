    Assembly[] assemblies = GetYourAssemblies();
    builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.IsAssignableFrom(typeof(IHandler<>)))
        .AsSelf()
        .AsImplementedInterfaces();
