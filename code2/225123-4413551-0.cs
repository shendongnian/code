    public class SourceObject
    {
    	public bool   Value1   = true;
    	public string Value2   = "10";
    	public string StrValue = "test";
    }
    
    public class DestObject
    {
    	[MapField("Value1")] public bool   BoolValue;
    	[MapField("Value2")] public int    IntValue;
    
    	// If source and destination field or property names are equal,
    	// there is no need to use MapField attribute.
    	//
    	public string StrValue; 
    }
    
    public void Test()
    {
        SourceObject source = new SourceObject();
        DestObject   dest   = Map.ObjectToObject<DestObject>(source);
    }
