    class MyLoggerAdapter : Library.ILogger 
    {
        private readonly ILog _delegation;
    
        public MyLoggerAdapter(ILog delegation)
        {
            _delegation = delegation;
        }
    
        public void ILogger.Debug(string msg, params object[] p)
        {
            _delegation.Debug(msg, p); 
        }
    }
