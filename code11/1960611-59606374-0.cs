    //...
    cfg.For<IServerInformationDataAccess>()
        .Use<ServerInformationDataAccess>(c => { //<-- c in this case is a container context
            var connectionString = Configuration.GetConnectionString(DbConnectionKey);
            var mapper = c.GetInstance<IMapper>();
            return new ServerInformationDataAccess(connectionString, mapper);
        });
    //...
