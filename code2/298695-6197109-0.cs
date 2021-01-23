    public interface ILogger
    {
      void WriteDebug(string debug);
      void WriteInfo(string info);
      void WriteError(string error);
    }
    public class NullLogger : ILogger
    {
      private static ILogger instance = new NullLogger();
      // This singleton pattern is just here for convenience.
      // We do this because pattern has you using null loggers constantly.
      // If you use dependency injection elsewhere,
      // try to avoid the temptation of implementing more singletons :)
      public static ILogger Instance
      {
        get { return instance; }
      }
      public void WriteDebug(string debug) { }
      public void WriteInfo(string info) { }
      public void WriteError(string error) { }
    }
    public class SomeBusinessLogic
    {
      private ILogger logger = NullLogger.Instance;
      public SomeBusinessLogic()
      {
      }
      public void DoSomething()
      {
        logger.WriteInfo("some info to put in the log");
      }
      public ILogger Logger
      {
         get { return logger; }
         set { logger = value; }
      }
    }
    public class Program
    {
      static void Main(string[] args)
      {
        // The component won't know which logger it is using - it just uses it
        var someBusinessLogic = new SomeBusinessLogic()
        {
          // You're free to use a dependency injection library for this,
          // or simply check for a DLL via reflections and load a logger from there
          Logger = new FileLogger("logfile.txt"),
        };
        someBusinessLogic.DoSomething();
      }
    }
