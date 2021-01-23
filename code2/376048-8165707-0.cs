    IEnumerable<GameServer> gameServesWIthConnectedClients = from x in gameServers 
                           where x.ConnectedClients != null  
                           select x;
    var connectedClients = from y in gameServesWIthConnectedClients
                           select
                               new
                                   {
                                       y.Name,
                                       y.GameType,
                                       ConnectedClients =
                               new
                                   {
                                       y.ConnectedClients.ClientName,
                                       y.ConnectedClients.ConnectedOn,
                                       y.ConnectedClients.ClientIpAddressAndPort
                                   }
                                   };
    connectedClients = connectedClients.ToList();
