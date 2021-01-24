    /// <summary> Represents settings configured in appsettings.json file </summary>
    public class Settings
    {
        /// <summary> Option 1: move connection strings to custom strong typed Settings class </summary>
        public Connections ConnectionStrings { get; set; }
    
        /// <summary> Option 2: store DB settings any custom way you like - also to get via strong typed Settings class </summary>
        public Database DatabaseSettings { get; set; }
    }
    
    public class Connections
    {
        public string MyConnection { get; set; }
    }
    
    public class Database
    {
        public bool UseInMemory { get; set; }
        public string Host { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string BuildConnectionString() => $"Server={Host};Database={Name};User Id={User};Password={Password}";
    }
