        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseApplicationInsights()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Parse("0.0.0.0"), 5000);
                })
                .Build();
