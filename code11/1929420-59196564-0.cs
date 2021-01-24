    private IServiceCollection ConfigureLogging(IServiceCollection factory)
    {
          factory.AddLogging(opt =>
                             {
                                   opt.AddConsole();
                             })
          return factory;
    }
