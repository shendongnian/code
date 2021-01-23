    var container = new Container();
    var assemblies = GetAssemblies().ToArray();
    container.Register<IMediator, Mediator>();
    container.RegisterManyForOpenGeneric(typeof(IRequestHandler<,>), assemblies);
    container.RegisterManyForOpenGeneric(typeof(IAsyncRequestHandler<,>), assemblies);
    container.RegisterManyForOpenGeneric(typeof(INotificationHandler<>), container.RegisterAll, assemblies);
    container.RegisterManyForOpenGeneric(typeof(IAsyncNotificationHandler<>), container.RegisterAll, assemblies);
