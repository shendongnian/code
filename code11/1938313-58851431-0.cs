        private void ConnectToCentralManagementServer()
        {
            var serverConnection = new ServerConnection
            {                
                LoginSecure = false,
                ServerInstance = "localhost",
                Login = "UserName",
                Password = "Password",
                DatabaseName = "Database",                
            };
            var registeredServersStore = new RegisteredServersStore(serverConnection);
            var databaseEngineServerGroup = registeredServersStore.ServerGroups["DatabaseEngineServerGroup"];
            var serverName = "TestServer";
            var registeredServer = new RegisteredServer(serverName)
            {
                Parent = databaseEngineServerGroup,
                ConnectionString = testConnectionString,
                Description = "This is a sample connection to Test server",
                ServerName = "TestServer",                
            };
            if (databaseEngineServerGroup.RegisteredServers.Count(c => c.Name == serverName) == 0)
            {
                registeredServer.Create();
            }
        }    
