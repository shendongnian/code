    public interface IDataConfig {
        string ConnectionString { get; set; }
    }
    public interface IIdentityServerConfig {
        string Authority { get; set; }
    }
    public interface IStorageConfig {
        string AzureStorageConnectionString { get; set; }
    }
