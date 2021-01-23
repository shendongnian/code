    using log4net;
    using log4net.Appender;
    using log4net.Layout;
    using log4net.Repository.Hierarchy;
    
    namespace LoggerTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                DeviceConnection dev1 = new DeviceConnection("Device1");
                DeviceConnection dev2 = new DeviceConnection("Device2");
    
                dev1.DoSomething();
                dev2.DoSomething();
            }
        }
    
        public class DeviceConnection
        {
            private string name;
            private readonly ILog logger;
    
            public DeviceConnection(string _name)
            {
                name = _name;
    
                logger = TestLogger.AddNamedLogger(name);
    
                logger.Info("----  Begin Logging for DeviceConnection: " + name);
            }
    
            public void DoSomething()
            {
                logger.Info("Doing something for device connection " + name);
            }
        }
    
        public static class TestLogger
        {
            private static PatternLayout _layout = new PatternLayout();
            private const string LOG_PATTERN = "%d [%t] %-5p %m%n";
    
            public static string DefaultPattern
            {
                get { return LOG_PATTERN; }
            }
    
            static TestLogger()
            {
                _layout.ConversionPattern = DefaultPattern;
                _layout.ActivateOptions();
    
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                hierarchy.Configured = true;
            }
    
            public static PatternLayout DefaultLayout
            {
                get { return _layout; }
            }
    
            public static ILog AddNamedLogger(string name)
            {
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                Logger newLogger = hierarchy.GetLogger(name) as Logger;
    
                PatternLayout patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = LOG_PATTERN;
                patternLayout.ActivateOptions();
    
                RollingFileAppender roller = new RollingFileAppender();
                roller.Layout = patternLayout;
                roller.AppendToFile = true;
                roller.RollingStyle = RollingFileAppender.RollingMode.Size;
                roller.MaxSizeRollBackups = 4;
                roller.MaximumFileSize = "100KB";
                roller.StaticLogFileName = true;
                roller.File = name + ".log";
                roller.ActivateOptions();
    
                newLogger.AddAppender(roller);
    
                return LogManager.GetLogger(name);
            }
        }
    }
