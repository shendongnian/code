    using System;
    using System.IO;
    
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
    
    public class FileLogger : ILogger, IDisposable
    {
        private StreamWriter fileWriter;
    
        public FileLogger(string filename)
        {
            this.fileWriter = File.CreateText(filename);
        }
    
        public void Dispose()
        {
            if (fileWriter != null)
                fileWriter.Dispose();
        }
    
        public void WriteDebug(string debug)
        {
            fileWriter.WriteLine("Debug - {0}", debug);
        }
    
        // WriteInfo, etc
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
            // You're free to use a dependency injection library for this,
            // or simply check for a DLL via reflections and load a logger from there
            using (var logger = new FileLogger("logfile.txt"))
            {
                var someBusinessLogic = new SomeBusinessLogic()
                {
                    // The component won't know which logger it is using - it just uses it
                    Logger = logger,
                };
    
                someBusinessLogic.DoSomething();
            }
        }
    }
