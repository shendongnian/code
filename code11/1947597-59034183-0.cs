    public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        var p = System.Reflection.Assembly.GetEntryAssembly().Location;
                        p = p.Substring(0, p.LastIndexOf(@"\") + 1);
    
                        webBuilder.UseContentRoot(p);
                        webBuilder.UseStartup<Startup>();
                    });
