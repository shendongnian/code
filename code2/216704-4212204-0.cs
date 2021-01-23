        ConnectionStringSettings connSttng = new ConnectionStringSettings();
        connSttng.Name = "ConnectionStringName";
        connSttng.ProviderName = "Providername";
        connSttng.ConnectionString = String.Format("DataSource={0};InitialCatalog={1};IntegratedSecurity={2}", connectionStringBuilder.DataSource, connectionStringBuilder.InitialCatalog, connectionStringBuilder.IntegratedSecurity);
        
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        config.ConnectionStrings.ConnectionStrings.Add(connSttng);
        config.Save(ConfigurationSaveMode.Modified, true);
        ConfigurationManager.RefreshSection("connectionStrings");
