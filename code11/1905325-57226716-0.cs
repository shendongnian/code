        public MyServer(string url)
        {
            var configuration =
                new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                        ["urls"] = url
                    })
                    .Build();
            _host =
                new WebHostBuilder()
                    .UseKestrel()
                    //.UseUrls(url) // <-- cannot use this, seems to be deprecated
                    //.Configure(app => { app.UsePathBase(url); }) // <-- does not work
                    .UseConfiguration(configuration)
                    .UseStartup<MyStartup>()
                    .Build();
            Task = _host.StartAsync();
        }
