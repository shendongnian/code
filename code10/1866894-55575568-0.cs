    static void Main(string[] args)
    {
        // Arrange
        Container = new UnityContainer();
        Container.AddExtension(new Diagnostic());
    
    
        Container.RegisterType<IMessageReader, ConsoleMessageReader>();
        Container.RegisterType<IMessageWriter, ConsoleMessageWriter>();
    
        Container.RegisterType<IMessageReader, TwitterMessageReader>("Social");
        Container.RegisterType<IMessageWriter, FacebookMessageWriter>("Social");
        Container.RegisterType<IStartup, Startup>("Social", new InjectionConstructor(new ResolvedParameter<IMessageReader>("Social"), new ResolvedParameter<IMessageWriter>("Social")));
    
        Container.RegisterType<IMessageReader, ConsoleMessageReader>("Local");
        Container.RegisterType<IMessageWriter, ConsoleMessageWriter>("Local");
    
        var reader = Container.Resolve<IMessageReader>("Social");
        var writer = Container.Resolve<IMessageWriter>();
    
        Container.RegisterType<IStartup, Startup>("Local", new InjectionConstructor(reader, writer));
    
        IStartup startup = Container.Resolve<IStartup>("Local");
    
        // Act
        startup.Run();
    }
