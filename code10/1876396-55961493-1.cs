        [TestMethod]
        public void InitAppConfig(string customerValue)
        {
           var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
           config.AppSettings.Settings.Remove("Customer");
           config.AppSettings.Settings.Add("Customer", customerValue);
           config.Save();
           ConfigurationManager.RefreshSection("connectionStrings");
        }
