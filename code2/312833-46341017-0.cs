    [AttributeUsage(AttributeTargets.Method)]
    public class AttributeHelp : Attribute
    {
    	public string MyPropertyAttribute { get; private set; }
    	
    	public AttributeHelp(string myproperty)
    	{
    		this.MyPropertyAttribute = myproperty;
    	}
    }
