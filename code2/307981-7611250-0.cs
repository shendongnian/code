    using System.Runtime.Remoting.Messaging;
    public static class Variables
    {
	static Variables()
	{
		m_wClass = new WorkerClass();
		// creates and registers an event timer
		m_flushTimer = new System.Timers.Timer(1000);
		m_flushTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnFlushTimer);
		m_flushTimer.Start();
	}
	private static void OnFlushTimer(object o, System.Timers.ElapsedEventArgs args)
	{
		// determine the frequency of your update
		if (System.DateTime.Now - m_timer1LastUpdateTime > new System.TimeSpan(0,1,0))
		{
			// call your class to do the update
			m_wClass.DoMyThing();
			m_timer1LastUpdateTime = System.DateTime.Now;
		}
	}
	private static readonly System.Timers.Timer m_flushTimer;
	private static System.DateTime m_timer1LastUpdateTime = System.DateTime.MinValue;
	private static readonly WorkerClass m_wClass;
    }
    public class WorkerClass
    {
	public delegate WorkerClass MyDelegate();
	public void DoMyThing()
	{
		m_test = "Hi";
		m_test2 = "Bye";
		//create async call to do the work
		MyDelegate myDel = new MyDelegate(Execute);
		AsyncCallback cb = new AsyncCallback(CommandCallBack);
		IAsyncResult ar = myDel.BeginInvoke(cb, null);
	}
	private WorkerClass Execute()
	{
		//do my stuff in an async call
		m_test2 = "Later";
		return this;
	}
	public void CommandCallBack(IAsyncResult ar)
	{
		// this is called when your task is complete
		AsyncResult asyncResult = (AsyncResult)ar;
		MyDelegate myDel = (MyDelegate)asyncResult.AsyncDelegate;
		WorkerClass command = myDel.EndInvoke(ar);
		// command is a reference to the original class that envoked the async call
		// m_test will equal "Hi"
		// m_test2 will equal "Later";
	}
	private string m_test;
	private string m_test2;
    }
