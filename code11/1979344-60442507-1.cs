    public class Class1
    {
    	// since your response json has camelCasing, you will need to define JsonProperty to represent camelCasing or just use public string property1 { get; set; } without any decoration.
    	[JsonProperty("property1")]
    	public string Property1 { get; set; }
    
    	[JsonProperty("property2")]
    	public string Property2 { get; set; }
    
    	[JsonProperty("property3")]
    	public EmptyClass Property3 { get; set; }
    
    	[JsonProperty("property4")]
    	public IList<string> Property4 { get; set; }
    }
