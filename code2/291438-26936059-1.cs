    interface IFooBar
    {
    	void Foo(object bar);
    }
    
    public class FooBar : IFooBar
    {
    
    
    	public void Foo(object bar)
    	{
    		if(bar == null)
    		{
    			//Old and Busted
    			//throw new ArgumentException("bar");
    			//The new HOTNESS
    			throw new ArgumentException(nameof(bar)); // nameof(bar) returns "bar"
    		}
    
    		//....
    	}
    	
    }
