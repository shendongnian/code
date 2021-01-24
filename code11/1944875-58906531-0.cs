    public class DefaultValueAttribute:Attribute
    {
    	public object DefaultValue{get;set;}
    	public DefaultValueAttribute(object defaultValue)=>DefaultValue = defaultValue;
    }
