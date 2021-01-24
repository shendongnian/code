    public class ConfigSetup
    {
        public static void SetupConfig()
        {
            Config.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
    }
