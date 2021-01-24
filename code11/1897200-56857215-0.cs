    public class ApiRequest
    {
    	[JsonProperty("commands")]
        public List<Command> Commands { get; set; }
    	
    	public ApiRequest() 
    	{
    		Commands = new List<Command>();
    	}
    	
    	public void Add(Command command)
    	{
    	    Commands.Add(command);	
    	}
    }
    
    public class Command : Dictionary<string, string>
    {
    	public Command(string key, string value) : base()
    	{
    		Add(key, value);
    	}
    }
