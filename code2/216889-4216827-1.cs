    //Create the object
    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    //make changes
    config.AppSettings.Settings["Username"].Value = txtUsername.Text;
    config.AppSettings.Settings["Password"].Value = txtPassword.Text;
    
    //save to apply changes
    config.Save(ConfigurationSaveMode.Modified);
    ConfigurationManager.RefreshSection("appSettings");
