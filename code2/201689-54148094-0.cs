    // Register intercept as a log4net plugin
    [assembly: log4net.Config.Plugin(typeof(InterceptPlugin))]
    
    public class InterceptPlugin : log4net.Plugin.PluginSkeleton
    {
    	public InterceptPlugin() : base("Intercept") {}
    
    	public override void Attach(ILoggerRepository repository)
    	{
    		base.Attach(repository);
    
    		((Hierarchy)repository).LoggerFactory = new InterceptLoggerFactory();
    	}
    }
    
    // @jeremy-fizames's ILoggerFactory
    public class InterceptLoggerFactory : ILoggerFactory
    {
        public Logger CreateLogger(ILoggerRepository repository, string name)
        {
            if (name == null) return new InterceptRootLogger(repository.LevelMap.LookupWithDefault(Level.Debug));
            return new InterceptLogger(name);
        }
    
        class InterceptLogger : Logger
        {
            public InterceptLogger(string name) : base(name) {}
    
            protected override void CallAppenders(LoggingEvent loggingEvent)
            {
                // Implement interception of property on loggingEvent before any call to any appender (execution is sync).
                base.CallAppenders(loggingEvent);
            }
        }
    
        class InterceptRootLogger : RootLogger
        {
            public InterceptRootLogger(Level level) : base(level) {}
    
            protected override void CallAppenders(LoggingEvent loggingEvent)
            {
                // Implement interception of property on loggingEvent before any call to any appender (execution is sync).
                base.CallAppenders(loggingEvent);
            }
        }
    }
