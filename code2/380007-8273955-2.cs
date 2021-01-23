    public class Form1 : INotify
    {
            // This is the method where you instantiate the new worker process
            public void DoSomeWork() {
                NewClass Worker = New NewClass(this);
            }
    
            public delegate void NotifyDelegate(string Msg);
    
    	public void Notify(string Msg)
    	{
    		txtLog.Text += Msg + Environment.NewLine;
    	}
    
    	void INotify.Notify(string Msg)
    	{
    		this.INotify_Notify(Msg);
    	}
    	private void INotify_Notify(string Msg)
    	{
    		if (this.InvokeRequired)
    		{
    			this.Invoke(new NotifyDelegate(Notify), Msg);
    		}
    		else
    		{
    			this.Notify(Msg);
    		}
    	}
       }
