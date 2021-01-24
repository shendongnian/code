    var type = typeof(Application.UseCases.CloseAccount);
    services.Scan(scan => scan.FromAssembliesOf(type)
        .AddClasses(classes => classes.InExactNamespaceOf(type))
        .AsImplementedInterfaces()
        .WithScopedLifetime());
