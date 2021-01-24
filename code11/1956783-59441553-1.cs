    public static class Helper {
        public static FeedReadConfiguration GetApplicationConfiguration( ) {
            
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
    
            var iConfig = GetIConfigurationRoot(currentDirectory);
    
            FeedReadConfiguration configuration = iConfig.Get<FeedReadConfiguration>();
    
            return configuration;
        }
    
        public static IConfiguration GetIConfigurationRoot(string outputPath) {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }    
    }
