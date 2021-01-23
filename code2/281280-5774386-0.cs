    internal class BaseClass
    {
    	public BaseClass(Action myAction)
    	{
    		this.innterType = new InnterType(myAction);
    	}
    
    	public BaseClass()
    	{
    		// When no function delegate is supplied, InnterType should default to
    		// using its own implementation of the specific function
    		this.innterType = new InnterType();
    	}
    }
