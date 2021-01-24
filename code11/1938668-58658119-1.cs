new Thread(() =>
{
  Thread.CurrentThread.IsBackground = true;
  TcpListener server = null;
  while (true)
  {
    ...
    this.SynUI(()=>
    {
      if ( checkbox.Checked )
      {
      }
    });
    ...
  }
}).Start();
Or:
    ...
    bool checked = false;
    this.SynUI(()=> { checked = checkbox.Checked; });
    ...
Having:
static public class SyncUIHelper
{
  static public Thread MainThread { get; private set; }
  // Must be called from the Program.Main or the Main Form constructor for example
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
Adding in the Program.Main before the Application.Run:
    SyncUIHelper.Initialize();
You can find on stack overflow various ways to synchronize threads with the UI thread like:
https://stackoverflow.com/questions/661561/how-do-i-update-the-gui-from-another-thread
There is BackgroundWorker too.
