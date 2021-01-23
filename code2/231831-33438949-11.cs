    var container = new Container();
    var assemblies = GetAssemblies().ToArray();
    container.Register<IMediator, Mediator>();
    container.Register(typeof(IRequestHandler<,>), assemblies);
    container.Register(typeof(IAsyncRequestHandler<,>), assemblies);
    container.RegisterCollection(typeof(INotificationHandler<>), assemblies);
    container.RegisterCollection(typeof(IAsyncNotificationHandler<>), assemblies);
