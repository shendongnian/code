     public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logger => {
                    logger.AddDebug()
                          .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                    //logger.AddConsole(); //UnComment out this line if you did not use CreateDefaultBuilder
                });
