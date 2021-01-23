     public class MvcRoleProvider : RoleProvider
    {
        public string ConnectionString { get; set; }
        private IDataProvider _dataProvider;
        public override void Initialize(string name, NameValueCollection config)
        {
            DataProviderFactory factory = new DataProviderFactory();
            _dataProvider = factory.GetProvider(config["dataProviderAssembly"], config["dataProviderType"], ConfigurationManager.AppSettings[config["connectionStringName"]]);
            base.Initialize(name, config);
        }
