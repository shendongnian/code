    public sealed class ImmutablePropertyStore : MutablePropertyStore
    {
    	public new bool PropertyA { get; private set; }
    	public new bool PropertyB { get; private set; }
    	
    	public ImmutablePropertyStore()	{ }
    	
    	public ImmutablePropertyStore(MutablePropertyStore ms)
    	{
    		PropertyA = ms.PropertyA;
    		PropertyB = ms.PropertyB;
    	}
    	
    	public ImmutablePropertyStore(bool propertyA = true, bool propertyB = false)
    	{
    		PropertyA = propertyA;
    		PropertyB = propertyB;
    	}
    		
    	public override string ToString() 
    		=> $"Property A is '{PropertyA}' and Property B is '{PropertyB}'.";	
    }
    
    public class MutablePropertyStore
    {
    	public virtual bool PropertyA { get; set;}
    	public virtual bool PropertyB { get; set;}
    
    	// Set all defaults here
    	public MutablePropertyStore() { PropertyA = true; }
    
    	public override string ToString() 
    		=> $"Property A is '{PropertyA}' and Property B is '{PropertyB}'.";		 
    
    }
