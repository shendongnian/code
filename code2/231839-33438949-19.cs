    var container = new Container(cfg =>
    {
        cfg.Scan(scanner =>
        {
            scanner.AssemblyContainingType<Ping>();
            scanner.AssemblyContainingType<IMediator>();
            scanner.WithDefaultConventions();
            scanner.AddAllTypesOf(typeof(IRequestHandler<,>));
            scanner.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
            scanner.AddAllTypesOf(typeof(INotificationHandler<>));
            scanner.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
        });
    });
