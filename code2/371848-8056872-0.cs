    public class Class1
    {
       private BackgroundWorker _backgroundWorker = null;
       public Class1(BackgroundWorkerThread worker)
       {
         _backgroundWorker = worker;
         // rest of constructor
       }
       public void HeavyWorker()
       {
          // Heavy work
          // Have we been cancelled.
          if (_backgroundWorker != null && _backgroundWorker.CancellationPending)
          {
             // perform clean up and return
          }
           // Perform more heavy work.
       }
    } 
    private void backgroundWorker_DoWork(...)
    {
       Class1 obj = new Class1(backgroundWorker);
   
       obj.HeavyMethod();
    }
