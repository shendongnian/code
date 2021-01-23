    public class DbInfo
    {
        public DataBaseType dbType { get; set; }
        public SqlServerAuthenticationType sqlServerAuthType { get; set; }
        public string ConnectionString { get; set; }
        public string databaseAdress { get; set; }
        public string userId { get; set; }
        public string password { get; set; }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
    }
    public enum DataBaseType
    {
        Unknown = 0,
        Embedded = 1,
        Microsoft_SQL_Server =2,
    }
    public enum SqlServerAuthenticationType
    {
        Windows_Authentication = 0 ,
        SQL_Server_Authentication =1
    }
