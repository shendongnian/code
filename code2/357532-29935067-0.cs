        string str = "server=" + server + ";database=" + database + "; User ID=" + userid + "; Password=" + password + "";
        //Configuration myConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
        //str = System.Web.Configuration.WebConfigurationManager.AppSettings["myKey"];
        //myConfiguration.Save();
        System.Configuration.Configuration Config1 = WebConfigurationManager.OpenWebConfiguration("~");
        ConnectionStringsSection conSetting = (ConnectionStringsSection)Config1.GetSection("connectionStrings");
        ConnectionStringSettings StringSettings = new ConnectionStringSettings("conn", "Data Source=" + server + ";Database=" + database + ";User ID=" + userid + ";Password=" + password + ";");
        conSetting.ConnectionStrings.Remove(StringSettings);
        conSetting.ConnectionStrings.Add(StringSettings);
        Config1.Save(ConfigurationSaveMode.Modified);
        //Configuration myConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
        //myConfiguration.AppSettings.Settings.Item("myKey").Value = txtmyKey.Text;
        //myConfiguration.Save();
    }
