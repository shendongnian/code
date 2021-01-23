        public static Configuration ExeConfig()
        {
            Assembly service = Assembly.GetAssembly(typeof(YourClass));
            return ConfigurationManager.OpenExeConfiguration(service.Location);
        }
