    public class LevelManager
    {
    	[JsonProperty("version")]
    	public float Version { get; set; }
    	
    	[JsonProperty("health")]
    	public int Health { get; set; }
    	
    	[JsonProperty("powers")]
    	public Dictionary <string, int> Powers { get; set; }
    }
