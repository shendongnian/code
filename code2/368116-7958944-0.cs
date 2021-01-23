    [AttributeUsage(AttributeTargets.Property)]
    public class FooNameAttribute : Attribute
    {
    	public string PropertyName { get; private set; }
    
    	public FooNameAttribute(string propertyName)
    	{
    		PropertyName = propertyName;
    	}
    }
