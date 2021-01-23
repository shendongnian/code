    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    ConnectionStringsSection csSettings = config.GetSection("connectionStrings") as ConnectionStringsSection;
    if(csSettings != null)
    {
        // examples of removing all settings, adding a new one and removing it
        csSettings.ConnectionStrings.Clear();
        csSettings.ConnectionStrings.Add(new ConnectionStringSettings("myCS", "<connectionString>"));
        csSettings.ConnectionStrings.Remove("myCS");
        // save the changes
        config.Save(ConfigurationSaveMode.Modified);
    }
