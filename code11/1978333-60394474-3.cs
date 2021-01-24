    private void AddMysqlService(IServiceCollection services)
    {
        ILoggerFactory loggerFactory = CreateLoggerFactory(services.BuildServiceProvider());
        IMapper mapper = CreateMapperStartUp(services);
        services.AddSingleton<IConnection<Key>>(new ConnectionMannager(Configuration.GetSection("mysqlDb"), loggerFactory));
        var connectionMnamagerInstance = services.BuildServiceProvider().GetService<IConnection<Key>>();
        services.AddSingleton<IService<Key>>(new MysqlService(mapper, connectionMnamagerInstance));
    }
    
