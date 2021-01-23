    [AttributeUsage(AttributeTargets.Method)]
    public class AttributeCustom : Attribute
    {
    	public string MyPropertyAttribute { get; private set; }
    	
    	public AttributeCustom(string myproperty)
    	{
    		this.MyPropertyAttribute = myproperty;
    	}
    }
