               //Build the initial settings from the MongoConnectionString
            MongoClientSettings settings = MongoClientSettings.FromConnectionString("MongoConnectionString");
            //Subscribe on the following events
            settings.ClusterConfigurator += cb =>
                {
                    cb.Subscribe(delegate (CommandStartedEvent startedEvent) { Console.WriteLine($"Started: {startedEvent.Command} with OpId: {startedEvent.OperationId}"); });
                    cb.Subscribe(delegate (CommandSucceededEvent succeededEvent) { Console.WriteLine($"Succeeded OpId: {succeededEvent.OperationId}"); });
                    cb.Subscribe(delegate (CommandFailedEvent failedEvent) { Console.WriteLine($"Failed OpId: {failedEvent.OperationId}"); });
                };
            
            //Builld a MongoClient with the new Settings
            var client = new MongoClient(settings);
