     public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>()
            .ConfigureLogging((hostingContext, builder) =>
            {
                var loggingPath = hostingContext.Configuration.GetSection("Config");
                builder.AddFile(options=>
                   options.LogDirectory = loggingPath ; 
                   //...
                );
             
            });
           
