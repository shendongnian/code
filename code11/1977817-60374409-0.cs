    using System;
    using Newtonsoft.Json;
    
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"{'resource':{'fields':{'System.AreaPath':'someData','System.TeamProject':'someData','System.IterationPath':'someData'}}}";
    		var Sresponse = JsonConvert.DeserializeObject<RootObject>(json);
    		Console.WriteLine(Sresponse.resource.fields.AreaPath);
    		Console.WriteLine(Sresponse.resource.fields.TeamProject);
    		Console.WriteLine(Sresponse.resource.fields.IterationPath);
    
    	}
    }
    
    	public class Fields
    	{
    		[JsonProperty("System.AreaPath")]
    		public string AreaPath { get; set; }
    		[JsonProperty("System.TeamProject")]
    		public string TeamProject { get; set; }
    		[JsonProperty("System.IterationPath")]
    		public string IterationPath { get; set; }
    	}
    
    	public class Resource
    	{
    		public Fields fields { get; set; }
    	}
    
    	public class RootObject
    	{
    		public Resource resource { get; set; }
    	}
