    public static class Utils
        {
    
            public static string LoadSettingsFromFile(string environmentName)
            {
                var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                // We need to go back up one level as the appseetings.Release.json file is not put in the bin directory
                var actualPathToConfig = Path.Combine(executableLocation, $"..\\appsettings.{environmentName}.json");
                using (StreamReader reader = new StreamReader(actualPathToConfig))
                {
                    return reader.ReadToEnd();
                }
            }
    
            public static IConfiguration GetSettingsFromReleaseFile()
            {
                var json = Utils.LoadSettingsFromFile("Release");
                var memoryFileProvider = new InMemoryFileProvider(json);
    
                var config = new ConfigurationBuilder()
                    .AddJsonFile(memoryFileProvider, "appsettings.json", false, false)
                    .Build();
                return config;
            }
    
        }
