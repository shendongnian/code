            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).Build().Run();
            }
    
            public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            {
                return WebHost.CreateDefaultBuilder(args)                    
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseKestrel(options =>
                  {
                      options.Listen(IPAddress.Parse(0.0.0.0), Convert.ToInt32(5000));
                  })
                    .UseUrls("0.0.0.0:5000")
                    .UseStartup<Startup>();
            }
