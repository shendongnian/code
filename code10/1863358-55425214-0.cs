        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                    .UseSerilog((context, configuration) => configuration
                    .Enrich.FromLogContext()
                    .MinimumLevel.Debug()
                    .WriteTo.Console(),
                    preserveStaticLogger:true);
        }
