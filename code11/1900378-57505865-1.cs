    Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(ConfigurationManager.AppSettings["elasticsearchURL"]))
            {
                AutoRegisterTemplate = true,
                ModifyConnectionSettings = x => x.BasicAuthentication(ConfigurationManager.AppSettings["elasticsearchuserName"], ConfigurationManager.AppSettings["elasticsearchpassword"]),
                IndexFormat = ConfigurationManager.AppSettings["elasticsearchIndex"]
            })
            .CreateLogger();
			
