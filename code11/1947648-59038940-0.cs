    public class Root
    {
    	public string BrowserName { get; set; }
    	public string BrowserVersion { get; set; }
    	public string PlatformName { get; set; }
    	
    	[JsonProperty("sauce:options")]
    	public Options SauceOptions { get; set; }
    }
    
    public class Options
    {
    	public string Username { get; set; }
    	public string AccessKey { get; set; }
    }
