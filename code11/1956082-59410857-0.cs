    public class Program
        {
            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).Build().Run();
            }
    
            public static IHostBuilder CreateWebHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logger=>
                {
                    logger.AddConsole(x => x.TimestampFormat = "[HH:mm:ss] "); 
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseIIS();
                });
        }
