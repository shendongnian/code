    [JsonConverter(typeof(FlatternKeysConverter))]
    public class Module
    {
    	public string Name { get; set; }
    	public string[] Permission { get; set; }
    }
