    namespace log4netMultiLogTester
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                    Process.Start(new ProcessStartInfo("log4netMultiLogTester.exe", "testApp1"));
                    Process.Start(new ProcessStartInfo("log4netMultiLogTester.exe", "testApp2"));
                }
                else
                {
                    var logId = args[0];
                    var log = LogManager.GetLogger(logId);
    
                    GlobalContext.Properties["ServiceName"] = logId;
                    XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));
    
                    log.Info("Starting log: {0}".FormatWith(logId));
    
                    do
                    {
                        log.Info("Log: {0}, latest entry is {1}".FormatWith(logId,DateTime.Now.Ticks));
                    } while (Console.ReadKey().Key != ConsoleKey.R);
                }
            }
        }
    
        public static class StringExtensions
        {
            public static string FormatWith(this string text,params object[] args)
            {
                return string.Format(text, args);
            }
        }
    }
    <log4net>
      <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="[%utcdate] %-5level %logger: %message%newline%exception"/>
        </layout>
      </appender>
     
      <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
        <file type="log4net.Util.PatternString" value="Log/svc-%property{ServiceName}"/>
        <appendToFile value="true"/>
        <rollingStyle value="Date"/>
        <datePattern value="'-'yyyy'-'MM'-'dd'.log'"/>
        <staticLogFileName value="false"/>
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="[%utcdate] %-5level %logger: %message%newline%exception"/>
        </layout>
      </appender>
      
     <root>
        <level value="DEBUG"/>
        <appender-ref ref="ConsoleAppender"/>
        <appender-ref ref="RollingFileAppender"/>
      </root>
    </log4net>
