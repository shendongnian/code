    // Windsor 2.x
    container.Register(
        AllTypes.FromAssemblyNamed("MyApp.ServicesImpl")
        .Where(type => type.IsPublic)
        .WithService.FirstInterface()
        );
