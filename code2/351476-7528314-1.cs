    public class B
    {
    	public event EventHandler SomethingHappened;
    	public B()
    	{
    
    	}
    
    	void doSomething()
    	{
    		var ev = SomethingHappened;
    		if(ev != null)
    		{
    			ev(this, EventArgs.Empty);
    		}
    	}
    }
