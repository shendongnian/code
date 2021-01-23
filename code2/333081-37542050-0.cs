    class Program
        {
            private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            static void Main(string[] args)
            {
                log4net.GlobalContext.Properties["fname"] = "aaaa";
    
                log4net.Config.XmlConfigurator.Configure();
                log.Debug("Test");
            }
        }
