    public class ThingamajigLocatorProxy : IThingamajigLocator
    {
        private readonly IThingamajigLocator locator;
    
    	public ThingamajigLocatorProxy(IThingamajigLocator locator)
    	{
    	    this.locator = locator;
    	}
    	
    	public Thingamajig Locate()
    	{
    	    try
    		{
    		    return locator.Locate();
    		}
    		catch
    		{
    			// log exception
    			return new NullThingamajig();
    		}
    	}
    }
