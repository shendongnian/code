        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddDbConfiguration)
                .UseStartup<Startup>();
        private static void AddDbConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            var configuration = builder.Build();
            builder.AddXmlFile("appsettings.xml");
        }
