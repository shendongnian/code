    using System.Configuration;
    using System.Net.Configuration;
    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    var settings = (SettingsSection)config.GetSection("system.net/settings");
    settings.HttpWebRequest.UseUnsafeHeaderParsing = true;
    config.Save(ConfigurationSaveMode.Modified);
    ConfigurationManager.RefreshSection("system.net/settings");
