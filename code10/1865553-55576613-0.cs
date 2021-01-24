        app.Command("client", cmd =>
        {
            cmd.Description = "Start a client to listen to the service";
            cmd.HelpOption("--help");
            var userId = cmd.Argument("<userId>", "Set User ID");
            cmd.OnExecute(async () =>
            {
                var connectionString = connectionStringOption.Value() ?? configuration["Azure:SignalR:ConnectionString"];
                if (string.IsNullOrEmpty(connectionString) || !hubOption.HasValue())
                {
                    MissOptions();
                    return 0;
                }
                var client = new ClientHandler(connectionString, hubOption.Value(), userId.Value);
                await client.StartAsync();
    //Add the server to the client so we can talk both ways
                var server = new ServerHandler(connectionString, hubOption.Value());
                await server.Start();
                Console.ReadLine();
                await client.DisposeAsync();
                return 0;
            });
        });
