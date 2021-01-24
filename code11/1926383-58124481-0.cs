    static public class SyncUIHelper
    {
      static public Thread MainThread { get; private set; }
      // Must be called from the Program.Main or the Form constructor for example
      static public void Initialize()
      {
        MainThread = Thread.CurrentThread;
      }
      static public void SyncUI(this Control control, Action action, bool wait = true)
      {
        if ( !Thread.CurrentThread.IsAlive ) throw new ThreadStateException();
        Exception exception = null;
        Semaphore semaphore = null;
        Action processAction = () =>
        {
          try { action(); }
          catch ( Exception except ) { exception = except; }
        };
        Action processActionWait = () =>
        {
          processAction();
          if ( semaphore != null ) semaphore.Release();
        };
        if ( control != null
          && control.InvokeRequired
          && Thread.CurrentThread != MainThread )
        {
          if ( wait ) semaphore = new Semaphore(0, 1);
          control.BeginInvoke(wait ? processActionWait : processAction);
          if ( semaphore != null ) semaphore.WaitOne();
        }
        else
          processAction();
        if ( exception != null ) throw exception;
      }
    }
