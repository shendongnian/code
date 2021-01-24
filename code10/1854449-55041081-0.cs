    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }
   public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseKestrel(opt => {
                var sp = opt.ApplicationServices;
                using(var scope = sp.CreateScope() ){
                    var dbContext=scope.ServiceProvider.GetService<AppDbContext>();
                    var e= dbContext.Certificates.FirstOrDefault();
                    // now you get the certificates
                }
            });
    }
