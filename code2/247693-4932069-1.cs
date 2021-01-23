    public enum infringementCategory
    {
    	[Description("INF0001")]
    	Infringement,
    	[Description("INF0002")]
    	OFN
    }
    
    void Example()
    {
        infringementCategory category = infringementCategory.OFN;
        string description = category.GetDescriptionValue();
    }
    
    public static class DescriptionExtensions
    {
    	public static string GetDescriptionValue(this Enum value)
    	{
    		// Get the type
    		Type type = value.GetType();
    
    		// Get fieldinfo for this type
    		FieldInfo fieldInfo = type.GetField(value.ToString());
    
    		// Get the stringvalue attributes
    		DescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(
    			typeof(DescriptionAttribute), false) as DescriptionAttribute[];
    
    		// Return the first if there was a match.
    		return attribs.Length > 0 ? attribs[0].Description : null;
    	}
    }
