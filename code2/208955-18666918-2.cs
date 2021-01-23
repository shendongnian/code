            DatabaseSettings dataConfig = (DatabaseSettings)ConfigurationManager.GetSection("dataConfiguration");
            string configDefaultDatabase = string.Empty;
            if (null != dataConfig)
            {
                configDefaultDatabase = dataConfig.DefaultDatabase;
                if (!String.IsNullOrEmpty(configDefaultDatabase))
                {
                    ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
                    if (null == connections[configDefaultDatabase])
                    {
                        throw new ArgumentOutOfRangeException(
                            string.Format(
                                "Your dataConfiguration (DefaultDatabase) does not match any of your connection strings.  DefaultDatabase='{0}'.",
                                configDefaultDatabase));
                    }
                }
            }
