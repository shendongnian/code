    using System;//AppDomain
    using System.Linq;//Where
    using System.Configuration;//app.config
    using System.Reflection;//BindingFlags
        /// <summary>
        /// Use your own App.Config file instead of the default.
        /// </summary>
        /// <param name="NewAppConfigFullPathName"></param>
        public static void ChangeAppConfig(string NewAppConfigFullPathName)
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", NewAppConfigFullPathName);
            ResetConfigMechanism();
            return;
        }
        /// <summary>
        /// Remove cached values from ClientConfigPaths.
        /// Call this after changing path to App.Config.
        /// </summary>
        private static void ResetConfigMechanism()
        {
            BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;
            typeof(ConfigurationManager)
                .GetField("s_initState", Flags)
                .SetValue(null, 0);
            typeof(ConfigurationManager)
                .GetField("s_configSystem", Flags)
                .SetValue(null, null);
            typeof(ConfigurationManager)
                .Assembly.GetTypes()
                .Where(x => x.FullName == "System.Configuration.ClientConfigPaths")
                .First()
                .GetField("s_current", Flags)
                .SetValue(null, null);
            return;
        }
