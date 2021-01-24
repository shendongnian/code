    public static class ApiKeys {
        private static IConfiguration Config { get; set; }
        public static string PublicKey => Config.GetValue<string>( "service-public-key" );
        public static string SecretKey => Config.GetValue<string>( "service-secret-key" );
        static ApiKeys() {
            Config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            //.AddIniFile( "api-keys.ini", true ) // in this case you must add "api-keys.ini" to .gitignore file.
            .Build();
        }
    }
