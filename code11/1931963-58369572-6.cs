    public class X 
    {
    	public List<string> HtmlAttributions { get; set; }
    	public List<Result> Results { get; set; }
    }
    
    public class Result
    {
       public List<string> Types { get; set; }
       public string Vicinity { get; set; }
    }
    
    (...)
    
    var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };
    
    var x = JsonConvert.DeserializeObject<X>(json, settings); 
    
    Console.WriteLine(x.Results[0].Types[1]);
    Console.WriteLine(x.Results[0].Vicinity);
