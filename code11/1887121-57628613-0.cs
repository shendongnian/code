     return new HostBuilder()
                    .UseOrleans(builder =>
                    {
                        builder
                            .UseDashboard()
                            .UseAdoNetClustering(options =>
                            {
                                options.Invariant = "System.Data.SqlClient";
                                options.ConnectionString = _connectionString;
                            })
                            .Configure<EndpointOptions>(options =>
                            {
                                // Port to use for Silo-to-Silo
                                options.SiloPort = 11111;
                                // Port to use for the gateway
                                options.GatewayPort = 30000;
                                // IP Address to advertise in the cluster
                                options.AdvertisedIPAddress = IPAddress.Parse(GetExternalIpAddress());
                                // The socket used for silo-to-silo will bind to this endpoint
                                options.GatewayListeningEndpoint = new IPEndPoint(IPAddress.Any, 40000);
                                // The socket used by the gateway will bind to this endpoint
                                options.SiloListeningEndpoint = new IPEndPoint(IPAddress.Any, 50000);
                            })
                            .Configure<ClusterOptions>(options =>
                            {
                                options.ClusterId = "ClusterId-ForSign";
                                options.ServiceId = "ServiceId-ForSign";
                            })
                            .ConfigureApplicationParts(parts =>
                            {
                                parts.AddApplicationPart(typeof(UserService).Assembly).WithReferences();
                                parts.AddApplicationPart(typeof(CompanyService).Assembly).WithReferences();
                            });
                    })
                    .ConfigureServices(services =>
                    {
                        services.AddTransient<ICompanyRepository, CompanyRepository>();
                        services.AddTransient<ICompanyService, CompanyService>();
                        services.Configure<ConsoleLifetimeOptions>(options =>
                        {
                            options.SuppressStatusMessages = true;
                        });
                    })
                    .ConfigureLogging(builder =>
                    {
                        builder.AddConsole();
                    })
                    .RunConsoleAsync();
            }
    
            private static string GetExternalIpAddress() => new WebClient().DownloadString("https://api.ipify.org");
