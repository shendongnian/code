    var connectedClients = (from x in gameServers
                            where x.ConnectedClients != null
                            from y in x.ConnectedClients
                            select new
                            {
                                x.Name,
                                x.GameType,
                                ConnectedClients = new
                                {
                                    y.ClientName,
                                    y.ConnectedOn,
                                    y.ClientIpAddressAndPort
                                }
                            }).ToList();
