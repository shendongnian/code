c#        
public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                    webBuilder.UseIISIntegration();
                });
Here you can customize the web host. In your case to change the URL used you can use `webBuilder.UseUrls("Url 1", "Url 2"...)`
