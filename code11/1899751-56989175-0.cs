    public class Root : Dictionary<string, Building>
    {	
    	[JsonProperty("$base")]
    	public string Base { get; set; }
    	
    	[JsonProperty("nodeType")]
    	public string NodeType { get; set; }
    }
    
    public class Building
    {
    	[JsonProperty("$base")]
    	public string Base { get; set; }
    	
    	[JsonProperty("nodeType")]
    	public string NodeType { get; set; }
    	
    	[JsonProperty("truncated")]
    	public string Truncated { get; set; }
    }
