    public class Log
    {
        public void Info(string info) { /* ... */ }
        public void Warn(string info) { /* ... */ }
        public void Error(string info) { /* ... */ }
    }
    
    public class LogConsumer
    {
        private readonly Log _log;
        private readonly string _consumerName;
        
        public LogConsumer(Log log, string consumerName)
        {
            _log = log;
            _consumerName = consumerName;
        }
        
        public void Frobnicate()
            => _log.Info($"{nameof(Frobnicate)} called on {_consumerName}");
    }
    
    var container = new UnityContainer()
        .AddNewExtension<UnityParameterizedAutoFactoryExtension>();
        
    var logConsumerFactory = container.Resolve<Func<string, LogConsumer>>();
    var gadget = logConsumerFactory("Gadget");
    gadget.Frobnicate();
