    using log4net;
    using log4net.Config;
    using log4net.Repository;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    
    namespace MaxRateExample
    {
        public static class Program
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(Program));
    
            static void Main(string[] args)
            {
                ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine($"item-{i}");
                    log.Info($"item-{i}");
    
                    Thread.Sleep(10);
                }
            }
        }
    }
