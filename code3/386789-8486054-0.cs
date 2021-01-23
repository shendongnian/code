    public class LogFactory
    {
        private static LogFactory _instance;
    
        public static void Assign(LogFactory instance)
        {
            _instance = instance;
        }
    
        public static LogFactory Instance
        {
            get { _instance ?? (_instance = new LogFactory()); }
        }
        
        public virtual ILogger GetLogger<T>()
        {
            return new SystemDebugLogger();
        }
    }
