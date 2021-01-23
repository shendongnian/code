    Server server = new Server();
    server.ConnectionContext.ServerInstance = ServerName;
    server.ConnectionContext.LoginSecure = false;
    server.ConnectionContext.Login = "sa";
    server.ConnectionContext.Password = "123456";
    server.ConnectionContext.Connect();
