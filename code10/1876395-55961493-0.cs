        [TestMethod]
        public void InitAppConfig(string customerValue)
        {
            var config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
           config.AppSettings.Settings.Remove("Customer");
           config.AppSettings.Settings.Add("Customer", customerValue);
           config.Save();
           ConfigurationManager.RefreshSection("connectionStrings");
        }
