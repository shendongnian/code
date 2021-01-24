    public sealed class ImmutablePropertyStore : MutablePropertyStore
    {
    	public new bool PropertyA { get; }
    	public new bool PropertyB { get; }
    	
    	public ImmutablePropertyStore()	{ }
    	
    	public ImmutablePropertyStore(bool propertyA = true, bool propertyB = false)
    	{
    		PropertyA = propertyA;
    		PropertyB = propertyB;
    	}    		
    }
    
    public class MutablePropertyStore
    {
    	public bool PropertyA { get; set;}
    	public bool PropertyB { get; set;}
    
    	// Set all defaults here
    	public MutablePropertyStore() { PropertyA = true; }
    
    	public override string ToString() 
    		=> $"Property A is '{PropertyA}' and Property B is '{PropertyB}'.";		 
    
    }
