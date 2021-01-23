    class Program
    {
        static void Main(string[] args)
        {
            // you need this
            XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log.Error("test error", new Exception("error's exception", new Exception("error's innerexception")));
    
            Console.Read();
        }
    }
