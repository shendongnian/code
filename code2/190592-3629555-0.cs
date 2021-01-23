        public static ILogger GetLogger(string value)
        {
            ...
        }
    
        public static ILogger GetLogger():this(string.Empty)
        {
            //No Code in here since it wont be called
        }
