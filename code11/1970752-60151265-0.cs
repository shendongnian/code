    public class MongoDatabaseSettings : IDatabaseSettings
    {
        private const string Mongo = "Mongo:";
        public MongoDatabaseSettings(IConfiguration configuration)
        {
            Host = configuration.GetValue<string>($"{Mongo}{nameof(Host)}");
            Port = configuration.GetValue<int>($"{Mongo}{nameof(Port)}");
            DatabaseName = configuration.GetValue<string>($"{Mongo}{nameof(DatabaseName)}");
            Username = configuration.GetValue<string>($"{Mongo}{nameof(Username)}");
            Password = configuration.GetValue<string>($"{Mongo}{nameof(Password)}");
        }
        public string Host { get; }
        public int Port { get; } 
        public string DatabaseName { get; } 
        public string Username { get; } 
        public string Password { get; } 
    }
