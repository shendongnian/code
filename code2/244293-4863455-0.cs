    public static class Utility
    {
        private static Cache cache = new Cache();  // Static class variable
        #region "Configurations"
        public static String GetConfigurationValue(ConfigurationSection section, String key)
        {
            Configurations config = new Configurations();
            // Cache cache = new Cache(); --- removed
            ...
        }
    }
