    static class IISExpressManager
    {
        /// <summary>
        /// All started IIS Express hosts
        /// </summary>
        private static List<IISExpress> hosts = new List<IISExpress>();
        /// <summary>
        /// Start IIS Express hosts according to the config file
        /// </summary>
        public static void StartIfEnabled()
        {
            string enableIISExpress = ConfigurationManager.AppSettings["EnableIISExpress"]; // bool value from config file
            string pathToConfigFile = ConfigurationManager.AppSettings["IISExpressConfigFile"]; // path string to iis configuration file
            string quotedPathToConfigFile = '"' + pathToConfigFile + '"';
            if (bool.TryParse(enableIISExpress, out bool isIISExpressEnabled) 
                && isIISExpressEnabled && File.Exists(pathToConfigFile))
            {                
                hosts.Add(IISExpress.Start(
                    new Dictionary<string, string> {
                        {"systray", "false"},
                        {"config", quotedPathToConfigFile},
                        {"site", "Site1" }                        
                    }));
                hosts.Add(IISExpress.Start(
                    new Dictionary<string, string> {
                        {"systray", "false"},
                        { "config", quotedPathToConfigFile},
                        {"site", "Site2" }
                    }));
            }
        }
        /// <summary>
        /// Stop all started hosts
        /// </summary>
        public static void Stop()
        {
            foreach(var h in hosts)
            {
                h.Stop();
            }
        }
    }
