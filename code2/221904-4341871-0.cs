    public delegate void MyUserControlEvent(UserControl control, object sender, EventArgs e);
    
    public partial class MyUserControl : UserControl
    {
    	public event MyUserControlEvent TheEvent;
    	
    	private void TimerFecha_Tick(object sender, EventArgs e)
    	{
    		if (TheEvent != null) { TheEvent(this, sender, e); }
    	}
    }
    
    public partial class SomeClient : SomeBase
    {
    	public SomeClient()
    	{		
    		MyUserControl control = new MyUserControl();
    		control.TheEvent = TheListenerProcedure;
    	}
    	
    	public void TheListenerProcedure(UserControl control, object sender, EventArgs e)
    	{
    		/* IMPLEMENT LOGIC HERE */
    	}	
    }
