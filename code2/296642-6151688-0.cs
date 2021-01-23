    public abstract class AppConfig : IDisposable
    {
        public static AppConfig Change(string path)
        {
            return new ChangeAppConfig(path);
        }
        public abstract void Dispose();
        private class ChangeAppConfig : AppConfig
        {
            #region Variables
            private readonly string oldConfig =
                AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString();
            private bool disposedValue;
            #endregion
            public ChangeAppConfig(string path)
            {
                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", path);
                ResetConfigMechanism();
            }
            public override void Dispose()
            {
                if (!disposedValue)
                {
                    AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", oldConfig);
                    ResetConfigMechanism();
                    disposedValue = true;
                }
                GC.SuppressFinalize(this);
            }
            private static void ResetConfigMechanism()
            {
                typeof(ConfigurationManager).GetField("s_initState",
                                                      BindingFlags.NonPublic | BindingFlags.Static).
                    SetValue(null, 0);
                typeof(ConfigurationManager).GetField("s_configSystem",
                                                      BindingFlags.NonPublic | BindingFlags.Static).
                    SetValue(null, null);
                typeof(ConfigurationManager).Assembly.GetTypes().Where(x => x.FullName == "System.Configuration.ClientConfigPaths").First().clientConfigPathType.GetField("s_current", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, null);
            }
        }
    }
