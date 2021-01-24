    public class Serilog
    {
    	[JsonProperty("MinimumLevel ")]
    	public string MinimumLevel { get; set; }
    
    	[JsonProperty("WriteTo")]
    	public List<WriteTo> WriteTo { get; set; }
    }
