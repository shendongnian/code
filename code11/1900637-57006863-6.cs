    public class ConfigSettings
    {
    	public Spring spring { get; set; }
    	public Logging Logging { get; set; }
    }
    
    public class Spring
    {
    	public Cloud cloud { get; set; }
    }
    
    public class Cloud
    {
    	public Config config { get; set; }
    }
    
    public class Config
    {
    	public string uri { get; set; }
    }
    
    public class Logging
    {
    	public bool IncludeScopes { get; set; }
    	public Loglevel LogLevel { get; set; }
    	public Console Console { get; set; }
    }
    
    public class Console
    {
    	public Loglevel LogLevel { get; set; }
    }
    
    public class Loglevel
    {
    	public string Default { get; set; }
    	public string System { get; set; }
    	public string Microsoft { get; set; }
    }
