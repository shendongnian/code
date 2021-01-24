    public class Foo
    {
    	public string Bar { get; set; }
    	
    	public bool ShouldSerializeBar()
    	{
    		return false;
    	}
    }
