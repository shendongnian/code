    public class MyObject
    {
    	[JsonConverter(typeof(ArrayConverter<bool>))]
    	public bool FlagCalculateclientside { get; set; }
    	[JsonConverter(typeof(ArrayConverter<string>))]
    	public string Description { get; set; }
    	[JsonConverter(typeof(ArrayConverter<string>))]
    	public string Name { get; set; }
    }
