    public class Program
    {
    	public static void Main(string[] args)
    	{
    		List<Result> resultList = new List<Result>
    		{
    			new Result 
    			{
    				score1 = 1,
    				score2 = 2,
    				id = "15"
    			},
    			new Result
    			{
    				score1 = 3,
    				score2 = 4,
    				id = "12"
    			}
    		};
    		
    
    
    		
    		var valuesList = JArray.FromObject(resultList).Select(x => x.Values().ToList()).ToList();
    		
    		string finalRes = JsonConvert.SerializeObject(valuesList, Formatting.Indented);
    		
    		Console.WriteLine(finalRes);
    	}
    }
            
    public class Result
    {
    	 public int? score1 {get; set; }
    	 public int? score2 { get; set; }   
    	 public string id { get; set; }
    }
	
