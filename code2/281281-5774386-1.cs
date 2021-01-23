    internal class BaseClass
    {
    	public BaseClass(Action myAction)
    	{
    		this.innerType = new InnerType(myAction);
    	}
    
    	public BaseClass()
    	{
    		// When no function delegate is supplied, InnerType should default to
    		// using its own implementation of the specific function
    		this.innerType = new InnerType();
    	}
    }
