    public class Monitor
    {
    	private bool _cancel = false;
    
    	public void Cancel()
    	{
    		_cancel = true;
    	}
    
    	public void CurrUsage(Nics nics, int n)
    	{ 
    		_cancel = false;
    		// ...
    		while (!_cancel)
    		{
    		// do some stuff
    		}
    	}
    }
