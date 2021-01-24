    public class Parent
    {
    	[JsonProperty("name")]
    	public string Name { get; set; }
    
    	[JsonProperty("Children")]
    	public Children Children { get; set; }
    }
    
    public class Children
    {
    	[JsonProperty("item")]
    	public Dictionary<string, string> Items { get; set; }
    }
