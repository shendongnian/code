    public class JsonArgs 
    {
    	//Removed List of string and create args class
    	public args args;
    
    	//Removed List of headers
    	public headers headers;
    	public string origin;
    	public string url;
    }
    
    public class headers
    {
    	[JsonProperty("Accept")]
    	public string Accept;
    
    	[JsonProperty("Accept-Encoding")]
    	public string Accept_Encoding;
    
    	[JsonProperty("Accept-Language")]
    	public string Accept_Language;
    
    	[JsonProperty("Cache-Control")]
    	public string Cache_Control;
    
    	[JsonProperty("Host")]
    	public string Host;
    
    	[JsonProperty("If-Modified-Since")]
    	public string If_Modified_Since;
    
    	[JsonProperty("Upgrade-Insecure-Requests")]
    	public string Upgrade_Insecure_Requests;
    
    	[JsonProperty("User-Agent")]
    	public string User_Agent;
    } 
    	
    public class args
    {
    
    }
