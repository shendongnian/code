    public class Root
    {
    	public Dictionary<string, Node> Nodes { get; set; }
    }
    
    public class Node
    {
    	[JsonProperty("node_id")]
    	public string NodeId { get; set; }
        // The other properties are left for you to fill out...
    }
