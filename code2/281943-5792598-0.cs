    Assembly[] assemblies = GetYourAssemblies();
    builder.RegisterAssemblyTypes(assemblies)
        .Where(t => t.GetCustomAttributes(t.IsAssignableFrom(typeof(IHandler<>)))
        .AsSelf()
        .AsImplementedInterfaces();
