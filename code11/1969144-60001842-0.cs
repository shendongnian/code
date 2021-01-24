    protected void Application_Start()
        {
            Conversation.UpdateContainer(
            builder =>
            {
                builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));
                // Bot Storage: register state storage for your bot
                // Default store: volatile in-memory store - Only for prototyping!
                // var store = new InMemoryDataStore();
                // This sample will use Azure Table Storage 
                //var store = new TableBotDataStore(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
                var store = new InMemoryDataStore();
                builder.Register(c => store)
                    .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                    .AsSelf()
                    .SingleInstance();
            });
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
