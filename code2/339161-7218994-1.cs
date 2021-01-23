    var procTypes = AppDomain.CurrentDomain
        .GetAssemblies()
        .SelectMany(x => x.GetTypes())
        .Where(x => x.IsDerivedFromOpenGenericType(typeof(IProcess<,>)))
        .ToList();
    foreach (var procType in procTypes)
    {
        var procInterfaces = procType.GetInterfaces()
            .Where(x => x.IsDerivedFromOpenGenericType(typeof (IProcess<,>)))
            .ToArray();
        container.Register(Component.For(procInterfaces).ImplementedBy(procType).LifeStyle.Transient);
    }
