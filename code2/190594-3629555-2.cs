        public static ILogger GetLogger(string value)
        {
            ...
        }
    
        public static ILogger GetLogger()
        {
            return GetLogger("Default Value");
        }
