    public class Element<T>
    {
    	public Element(T value, T defaultValue, string name)
    	{
    		Value = value;
    		DefaultValue = defaultValue;
    		TypeName = name
    	}
    	[JsonProperty(Required = Required.Always)]
    	public T Value { get; set; }
    	[JsonProperty(Required = Required.Always)]
    	public T DefaultValue { get; set; }
    	public string TypeName { get; set;}
    }
