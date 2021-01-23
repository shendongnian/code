    using (var connection = new SqlConnection(parameters.ConnectionStringToMasterDatabase))
                {
                    var serverConnection = new ServerConnection(connection);
                    try
                    {
                        var server = new Server(serverConnection);
                        // do something
                    }
                    finally
                    {
                        serverConnection.Disconnect();
                    }
                }
    using (var connection = new SqlConnection(parameters.ConnectionStringToMasterDatabase))
                {
                    var serverConnection = new ServerConnection(connection);
                    try
                    {
                        var server = new Server(serverConnection);
                        // do something else
                    }
                    finally
                    {
                        serverConnection.Disconnect();
                    }
                }
