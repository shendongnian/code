    using (var command = new SqlCommand(query, connection))
    {
        command.CommandTimeout = 0;              
        var infoCaptureHandler = new SqlInfoMessageEventHandler((sender, args) =>
            {
                if (!String.IsNullOrWhiteSpace(args.Message))
                {
                    Console.WriteLineLine(args.Message);
                }
            });
    
        connection.InfoMessage += infoCaptureHandler;
        try
        {
            command.ExecuteReader();
        }
        finally
        {
            connection.InfoMessage -= infoCaptureHandler;
        }
    }
