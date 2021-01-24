    private IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            //Configuration
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "otherconfig.json";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream)) {
                string result = reader.ReadToEnd();
                string tempPath = Path.GetTempFileName();
                File.WriteAllText(tempPath, result);
                builder.AddJsonFile(tempPath);
            }
            IConfiguration config = builder.Build();
            serviceCollection.AddSingleton(config);
            //other dependency injection service registration
            return serviceCollection.BuildServiceProvider();
        }
