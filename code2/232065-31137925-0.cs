        [STAThread]
        static void Main()
        {
            CreateConfigIfNotExists();
        }
        private static void CreateConfigIfNotExists()
        {
            string configFile = string.Format("{0}.config", Application.ExecutablePath);
            if (!File.Exists(configFile))
            {
                File.WriteAllText(configFile, Resources.App_Config);
            }
        }
