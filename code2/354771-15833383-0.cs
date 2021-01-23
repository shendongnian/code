     [TestMethod]
        public void Test_general()
        {
            var cs = new ConnectionStringSettings();
            cs.Name = "ConnectionStrings.Oracle";
            cs.ConnectionString = "DATA SOURCE=xxx;PASSWORD=xxx;PERSIST SECURITY INFO=True;USER ID=xxx";
            cs.ProviderName = "Oracle.DataAccess.Client";
    
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.ConnectionStrings.ConnectionStrings.Clear();
            config.ConnectionStrings.ConnectionStrings.Remove(cs.Name);
            config.ConnectionStrings.ConnectionStrings.Add(cs);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            // your code for your test here
       }
