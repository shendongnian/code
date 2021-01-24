    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseSentry()
                    .UseKestrel(opts =>
                    {
                        opts.Listen(IPAddress.Any, 443, listenOpts =>
                        {
                            //Create the configuration to read from appsettings.json
                            var configuration = new ConfigurationBuilder().AddJsonFile(
                                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
                                .Build();
    
                            //Create the DB Context options
                            var optionsBuilder = new DbContextOptionsBuilder<DBContext>()
                                .UseSqlServer(configuration["ConnectionString:Development"]);
    
                            //Create a new database context
                            var context = new DBContext(optionsBuilder.Options);
                            
                            //Get the certificate
                            var certificate = context.Certificates.First();
                        });
                    });
