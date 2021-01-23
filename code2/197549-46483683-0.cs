    TfsTeamProjectCollection server = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(serverName));
    server.EnsureAuthenticated();
    
    var versionControlServer = server.GetService<VersionControlServer>();
    versionControlServer.ConfigureProxy(proxyName);
