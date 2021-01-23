     public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
    
        public LogicClass1()
        {
            logger.Debug("Here logger is NullLogger!");
        }
