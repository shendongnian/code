     public static void Initialize(IConfigManager configManager)
        {
            if (_instanceHolder == null)
            {
                lock (LockObject)
                {
                    if (_instanceHolder == null)
                    {
                        _instanceHolder = new AppConfig(configManager);
                        return;
                    }
                }
            }
            throw new ApplicationException("Initalize() method should be called only once.");
        }
        /// <summary>
        /// Instances the specified config manager.
        /// </summary>
        /// <returns></returns>
        public static AppConfig Instance
        {
            get
            {
                if (_instanceHolder == null)
                {
                    throw new ApplicationException("Singleton instance hasn't been initialized.");
                }
                return _instanceHolder;
            }
        }
