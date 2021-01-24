    public interface IDataConfig {
        public string ConnectionString { get; set; }
    }
    public interface IIdentityServerConfig {
        public string Authority { get; set; }
    }
    public interface IStorageConfig {
        public string AzureStorageConnectionString { get; set; }
    }
