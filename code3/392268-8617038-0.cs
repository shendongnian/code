    public delegate void MyEventHandler(object sender, EventArgs e);
    
    public event MyEventHandler MyEvent;
    
    public void OnMyEvent()
    {
    	if (this.MyEvent != null)
    	{
    		this.MyEvent(this, EventArgs.Empty);
    	}
    }
