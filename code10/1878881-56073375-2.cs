    public class GraphResponse
    {
    	[JsonProperty("odata.metadata")]
    	public string ODataMetaData { get; set; }
    	[JsonProperty("value")]
    	public IEnumerable<Value> Values { get; set; }
    }
    
    public class Value
    {
    	[JsonProperty("url")]
    	public string Url { get; set; }
    }
