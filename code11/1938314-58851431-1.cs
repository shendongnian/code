        private void ConnectToLocalServerGroup()
        {
            var databaseEngineServerGroup = RegisteredServersStore.LocalFileStore.ServerGroups["DatabaseEngineServerGroup"];
            var serverName = "Database on Sever";
            var registeredServer = new RegisteredServer(serverName)
            {
                Parent = databaseEngineServerGroup,
                ConnectionString = localConnectionString,
                Description = "This is a sample connection to Test server",
                ServerName = "Server",
            };
            if (databaseEngineServerGroup.RegisteredServers.Count(c => c.Name == serverName) == 0)
            {
                registeredServer.Create();
            }
        }
