    static void Main(string[] args)
    {
        var catalog = new AssemblyCatalog(typeof(Program).Assembly);
        var configuration = new InterceptionConfiguration()
            .AddInterceptor(new InitialisePluginStrategy());
        var interceptingCatalog = new InterceptingCatalog(catalog, configuration);
        var container = new CompositionContainer(interceptingCatalog);
        var logger = container.GetExportedValue<ILogger>();
        logger.Log("test");
        Console.ReadKey();
    }
