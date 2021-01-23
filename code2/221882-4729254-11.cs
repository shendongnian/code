    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace CorrelationManagerParallelTest
    {
      class Program 
      {     
        static void Main(string[] args)     
        { 
          //UseParallelFor(true) will assert because LogicalOperationStack will not have expected
          //number of entries, all others will run to completion.
        
          UseTasks(); //Equivalent to original test program with only the parallelized
                          //operation bracketed in logical operation.
          ////UseTasks(true); //Bracket entire UseTasks method in logical operation
          ////UseParallelFor();  //Equivalent to original test program, but use Parallel.For
                                 //rather than Tasks.  Bracket only the parallelized
                                 //operation in logical operation.
          ////UseParallelFor(true); //Bracket entire UseParallelFor method in logical operation
        }       
        
        private static List<int> threadIds = new List<int>();     
        private static object locker = new object();     
    
        private static int mainThreadId = Thread.CurrentThread.ManagedThreadId;
        
        private static int mainThreadUsedInDelegate = 0;
    
        // baseCount is the expected number of entries in the LogicalOperationStack
        // at the time that DoLongRunningWork starts.  If the entire operation is bracketed
        // externally by Start/StopLogicalOperation, then baseCount will be 1.  Otherwise,
        // it will be 0.
        private static void DoLongRunningWork(int baseCount)     
        {
          lock (locker)
          {
            //Keep a record of the managed thread used.             
            if (!threadIds.Contains(Thread.CurrentThread.ManagedThreadId))
              threadIds.Add(Thread.CurrentThread.ManagedThreadId);
    
            if (Thread.CurrentThread.ManagedThreadId == mainThreadId)
            {
              mainThreadUsedInDelegate++;
            }
          }         
    
          Guid lo1 = Guid.NewGuid();
          Trace.CorrelationManager.StartLogicalOperation(lo1);
          
          Guid g1 = Guid.NewGuid();         
          Trace.CorrelationManager.ActivityId = g1;
    
          Thread.Sleep(3000);         
          
          Guid g2 = Trace.CorrelationManager.ActivityId;
          Debug.Assert(g1.Equals(g2));
    
          //This assert, LogicalOperation.Count, will eventually fail if there is a logical operation
          //in effect when the Parallel.For operation was started.
          Debug.Assert(Trace.CorrelationManager.LogicalOperationStack.Count == baseCount + 1, string.Format("MainThread = {0}, Thread = {1}, Count = {2}, ExpectedCount = {3}", mainThreadId, Thread.CurrentThread.ManagedThreadId, Trace.CorrelationManager.LogicalOperationStack.Count, baseCount + 1));
          Debug.Assert(Trace.CorrelationManager.LogicalOperationStack.Peek().Equals(lo1), string.Format("MainThread = {0}, Thread = {1}, Count = {2}, ExpectedCount = {3}", mainThreadId, Thread.CurrentThread.ManagedThreadId, Trace.CorrelationManager.LogicalOperationStack.Peek(), lo1));
    
          Trace.CorrelationManager.StopLogicalOperation();
        } 
    
        private static void UseTasks(bool encloseInLogicalOperation = false)
        {
          int totalThreads = 100;
          TaskCreationOptions taskCreationOpt = TaskCreationOptions.None;
          Task task = null;
          Stopwatch stopwatch = new Stopwatch();
          stopwatch.Start();
    
          if (encloseInLogicalOperation)
          {
            Trace.CorrelationManager.StartLogicalOperation();
          }
    
          Task[] allTasks = new Task[totalThreads];
          for (int i = 0; i < totalThreads; i++)
          {
            task = Task.Factory.StartNew(() =>
            {
              DoLongRunningWork(encloseInLogicalOperation ? 1 : 0);
            }, taskCreationOpt);
            allTasks[i] = task;
          }
          Task.WaitAll(allTasks);
    
          if (encloseInLogicalOperation)
          {
            Trace.CorrelationManager.StopLogicalOperation();
          }
    
          stopwatch.Stop();
          Console.WriteLine(String.Format("Completed {0} tasks in {1} milliseconds", totalThreads, stopwatch.ElapsedMilliseconds));
          Console.WriteLine(String.Format("Used {0} threads", threadIds.Count));
          Console.WriteLine(String.Format("Main thread used in delegate {0} times", mainThreadUsedInDelegate));
    
          Console.ReadKey();
        }
    
        private static void UseParallelFor(bool encloseInLogicalOperation = false)
        {
          int totalThreads = 100;
          Stopwatch stopwatch = new Stopwatch();
          stopwatch.Start();
    
          if (encloseInLogicalOperation)
          {
            Trace.CorrelationManager.StartLogicalOperation();
          }
    
          Parallel.For(0, totalThreads, i =>
          {
            DoLongRunningWork(encloseInLogicalOperation ? 1 : 0);
          });
    
          if (encloseInLogicalOperation)
          {
            Trace.CorrelationManager.StopLogicalOperation();
          }
    
          stopwatch.Stop();
          Console.WriteLine(String.Format("Completed {0} tasks in {1} milliseconds", totalThreads, stopwatch.ElapsedMilliseconds));
          Console.WriteLine(String.Format("Used {0} threads", threadIds.Count));
          Console.WriteLine(String.Format("Main thread used in delegate {0} times", mainThreadUsedInDelegate));
    
          Console.ReadKey();
        }
    
      } 
    }
