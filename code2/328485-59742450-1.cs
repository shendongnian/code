    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using log4net;
    using log4net.Repository;
    
    namespace LogfilePerThread
    {
        class Program
        {
            static void Main(string[] args)
            {
                int nWorkers = 5; // 5 workers, 5 log files
                Task[] Workers = new Task[nWorkers];
                for (int i = 0; i < nWorkers; i++)
                {
                    int i1 = i;
                    Workers[i] = new Task(() => Work(i1));
                    Workers[i].Start();
                }
    
                Task.WaitAll(Workers);
                Console.WriteLine("Main executed.");
            }
    
            public static void Work(int workerID)
            {
                // Make sure the directory where logfiles are written exists
                string logfileName = $"Worker{workerID}_TaskLog"; // Logfile extension & path specified in App.config
                ILoggerRepository repository = LogManager.CreateRepository($"{logfileName}Repository");
                ThreadContext.Properties["WorkerLoggerProperty"] = logfileName;
                log4net.Config.XmlConfigurator.Configure(repository);
                ILog log = LogManager.GetLogger($"{logfileName}Repository", "WorkerLogger"); // Use this logger object in thread
    
                // Do work: Log & Sleep
                for (int i = 0; i < 5; i++)
                {
                    log.Info($"Logging from WorkerID={workerID} - Msg {i}");
                    Thread.Sleep(1000);
                }
            }
        }
    }
