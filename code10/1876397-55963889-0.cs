     public void ModifyAppConfig(string customer, string env)
        {
            var config = ConfigurationManager.AppSettings;           
            config.Set("CUSTOMER", customer);            
            config.Set("Environment", environment);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
