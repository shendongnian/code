    public class Config: IDataConfig, IIdentityServerConfig, IStorageConfig {
        public string ConnectionString { get; set; }
        public string Authority { get; set; }
        public string AzureStorageConnectionString { get; set; }
    }
