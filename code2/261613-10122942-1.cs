    using System.Web.Configuration;
    using System.Configuration;
    Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
    string oldValue = config.AppSettings.Settings["SomeKey"].Value;
    config.AppSettings.Settings["SomeKey"].Value = "NewValue";
    config.Save(ConfigurationSaveMode.Modified);
