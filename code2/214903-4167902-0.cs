        public static void SetConnectionString(string name, string connString, string webConfigPath)
        {
            string directory = System.IO.Path.GetDirectoryName(webConfigPath);
            VirtualDirectoryMapping vdm = new VirtualDirectoryMapping(directory, true);
            WebConfigurationFileMap wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
            webConfig.ConnectionStrings.ConnectionStrings[name].ConnectionString = connString;
            webConfig.Save();
        }
        public static void SetFromAddress(string email, string webConfigPath)
        {
            string directory = System.IO.Path.GetDirectoryName(webConfigPath);
            VirtualDirectoryMapping vdm = new VirtualDirectoryMapping(directory, true);
            WebConfigurationFileMap wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/"); 
            System.Net.Configuration.MailSettingsSectionGroup mailSettings = (System.Net.Configuration.MailSettingsSectionGroup)webConfig.GetSectionGroup("system.net/mailSettings");
            mailSettings.Smtp.From = email;
            webConfig.Save();
        }
