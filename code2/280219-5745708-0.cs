    var builder = new ContainerBuilder();
    builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
    builder.RegisterGeneric(typeof(EventLogger<>)).As(typeof(IEventLogger<>));
    builder.RegisterType<SomeBusinessObject>();
    builder.Register<Func<User, SomeBusinessObject>>(c => {
        // Autofac should be able to resolve these Func<> automatically:
        var loggerFactory = c.Resolve<Func<User, IEventLogger<SomeLogEventType>>>();
        var sboFactory = c.Resolve<Func<IEventLogger<SomeLogEventType>, SomeBusinessObject>>();
            // Now we can chain the Funcs:
        return u => sboFactory(loggerFactory(u));
    });
