    public class BackgroundProcessor : IDisposed
    {
      private Thread _backgroundThread;
      private bool _disposed;
      private AutoResetEvent _workToDo = new AutoResetEvent(false);
      // where T is a class with the set of parameters for your background work
      private Queue<T> _workQueue = Queue.Synchronized(new Queue<T>);
      public BackgroundProcessor()
      {
        _backgroundThread = new Thread(DoBackgroundWork);
        _backgroundThread.Start();
      }
      public void Dispose()
      {
        _disposed = true;
        // Wait 5 seconds for the processing of any previously submitted work to finish.
        // This gives you a clean exit.  May want to check return value for timeout and log
        // a warning if pending background work was not completed in time.
        // If you're not sure what you want to do yet, a Debug.Assert is a great place to
        // start because it will let you know if you do or don't go over time in general
        // in your debug builds.
        // Do *not* Join() and wait infinitely.  This is a great way to introduce shutdown
        // hangs into your app where your UI disappears but your process hangs around
        // invisibly forever.  Nasty problem to debug later...
        Debug.Assert(_backgroundThread.Join(5000)); 
      }
      // Called by your 'other application'
      public void GiveMeWorkToDo(T workParameters)
      {
        _workQueue.Enqueue(workParameters);
        _workToDo.Set();
      }
      private void DoBackgroundWork()
      {
        while (!_disposed)
        {
          // 500 ms timeout to WaitOne allows your Dispose event to be detected if there is
          // No work being submitted.  This is a fancier version of a Thread.Sleep(500)
          // loop.  This is better because you will immediately start work when a new
          // message is posted instead of waiting for the current Sleep statement to time
          // out first.
          _workToDo.WaitOne(500);
          // It's possible multiple sets of work accumulated or that the previous loop picked up the work and there's none left.  This is a thread safe way of handling this.
          T workParamters = _workQueue.Count > 0 ? workParameters = _workQueue.Dequeue() : null;
          do
          {
            DoSomething(workParameters);
            workParameters = _workQueue.Count > 0 ? workParameters = _workQueue.Dequeue() : null;
          } while (workParameters != null)
        }
      }
    }
