    void Main()
    {
    	Test t = new Test 
    	{
    	 Str = null,
    	 Val=1
    	};
    
    	var jsonSettings = new JsonSerializerSettings
    	{
    		NullValueHandling = NullValueHandling.Ignore,
    		MissingMemberHandling = MissingMemberHandling.Ignore
    	};
    
    	var json = JsonConvert.SerializeObject(t,jsonSettings);
    	
    	json.Dump();	
    
    	var result = JsonConvert.DeserializeObject<Test>(json, jsonSettings);
    	
    	result.Dump();
    }
    
    public class Test
    {
    	public string Str {get;set;}
    	
    	public int Val {get; set;}
    }
