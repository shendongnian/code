    public void ConfigureServices(IServiceCollection services)
    {
        services.Chain<IChainOfResponsibility>()
            .Add<HandlerOne>()
            .Add<HandlerTwo>()
            .Configure();
    }
