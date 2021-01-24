    Server = new TestServer(
                new WebHostBuilder()
                .ConfigureServices(services =>
                {
                   
                    services.Configure<SqlServerData>(Configuration.GetSection("SqlServerData"));
                    services.Configure<SolrData>(Configuration.GetSection("SolrData"));
                })
                .UseStartup<TestStartup>()
            );
