    using System;
    
    namespace TestEnvironmentVariable
    {
        class Program
        {
            static void Main(string[] args)
            {
                Settings settings = SettingsUtil.GetObjectFromJsonFile<Settings>("settings.json");
                Console.WriteLine($"Test environment: {settings.TestEnvironment}");
            }
        }
    }
