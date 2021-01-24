    using System.Collections.Specialized;
    using System.Configuration;
    using System.Reflection;
    public class LibrarySettings
    {
        private static NameValueCollection appSettings;
        public static NameValueCollection AppSettings
        {
            get
            {
                if (appSettings == null)
                {
                    appSettings = new NameValueCollection();
                    var assemblyLocation = Assembly.GetExecutingAssembly().Location;
                    var config = ConfigurationManager.OpenExeConfiguration(assemblyLocation);
                    foreach (var key in config.AppSettings.Settings.AllKeys)
                        appSettings.Add(key, config.AppSettings.Settings[key].Value);
                }
                return appSettings;
            }
        }
    }
