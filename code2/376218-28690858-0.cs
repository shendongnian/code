            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").ConnectionStrings.ConnectionStrings[connectionName];
            var split = config.ConnectionString.Split(Convert.ToChar(";"));
            var sb = new System.Text.StringBuilder();
            for (var i = 0; i <= (split.Length - 1); i++)
            {
                if (split[i].ToLower().Contains("user id"))
                {
                    split[i] += ";Password=" + password;
                }
                if (i < (split.Length - 1))
                {
                    sb.AppendFormat("{0};", split[i]);
                }
                else
                {
                    sb.Append(split[i]);
                }
            }
            return sb.ToString();
        }
        private static string CreateNewConnectionString2(string connectionName, string password)
        {
            var originalConnectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            var entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
            var providerBuilder = factory.CreateConnectionStringBuilder();
            providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;
            providerBuilder.Add("Password", password);
            entityBuilder.ProviderConnectionString = providerBuilder.ToString();
            return entityBuilder.ProviderConnectionString;
        }
        public ChineseStudyEntities()
            : base(CreateNewConnectionString("ChineseStudyEntities", "put YOUR password here")) // base("name=ChineseStudyEntities")
        {
        }
    
