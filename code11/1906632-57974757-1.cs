    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
               webBuilder.ConfigureKestrel(options =>
               {
                   options.Listen(IPAddress.Loopback, 55001, cfg =>
                   {
                       cfg.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
                   });
                   options.Listen(IPAddress.Loopback, 55002, cfg =>
                   {
                       cfg.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
                   }); 
               });
               webBuilder.UseStartup<Startup>();
           });
