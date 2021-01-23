    public class InterceptLoggerFactory : ILoggerFactory
    {
        public static void Apply() => Apply((Hierarchy)LogManager.GetRepository());
        public static void Apply(Hierarchy h) => h.LoggerFactory = new InterceptLoggerFactory();
        public Logger CreateLogger(ILoggerRepository repository, string name)
        {
            if (name == null) return new InterceptRootLogger(repository.LevelMap.LookupWithDefault(Level.Debug));
            return new InterceptLogger(name);
        }
        class InterceptLogger : Logger
        {
            public InterceptLogger(string name) : base(name)
            {
            }
            protected override void CallAppenders(LoggingEvent loggingEvent)
            {
                // Implement interception of property on loggingEvent before any call to any appender (execution is sync).
                /*
                 * var loggingEventData = loggingEvent.GetLoggingEventData();
                 * loggingEventData.Message = [EncryptMessage](loggingEventData.Message);
                 * var newLoggingEvent = new LoggingEvent(loggingEventData);
                 * base.CallAppenders(newLoggingEvent);
                 * */
                base.CallAppenders(loggingEvent);
            }
        }
        class InterceptRootLogger : RootLogger
        {
            public InterceptRootLogger(Level level) : base(level)
            {
            }
            protected override void CallAppenders(LoggingEvent loggingEvent)
            {
                // Implement interception of property on loggingEvent before any call to any appender (execution is sync).
                base.CallAppenders(loggingEvent);
            }
        }
    }
