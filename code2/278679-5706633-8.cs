    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using NLog;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace NLogMultiFileTest
    {
      class Program
      {
        public static Logger logger = LogManager.GetCurrentClassLogger();
    
        static void Main(string[] args)
        {
          
          int totalThreads = 50;
          TaskCreationOptions tco = TaskCreationOptions.None;
          Task task = null;
    
          logger.Info("Enter Main");
    
          Task[] allTasks = new Task[totalThreads];
          for (int i = 0; i < totalThreads; i++)
          {
            int ii = i;
            task = Task.Factory.StartNew(() =>
            {
              MDC.Set("id", "_" + ii.ToString() + "_");
              logger.Info("Enter delegate.  i = {0}", ii);
              logger.Info("Hello! from delegate.  i = {0}", ii);
              logger.Info("Exit delegate.  i = {0}", ii);
              MDC.Remove("id");
            });
    
            allTasks[i] = task;
          }
    
          logger.Info("Wait on tasks");
    
          Task.WaitAll(allTasks);
    
          logger.Info("Tasks finished");
    
          logger.Info("Exit Main");
        }
      }
    }
