    public interface iTbl
    {
    	int Property1 { get; set; }
    	string Property2 { get; set; }
    	
    	void WhatAreYou();
    }
    
    public class clsTblA : iTbl
    {
    	public int Property1 { get; set; }
    	public string Property2 { get; set; }
    	
    	public void WhatAreYou()
    	{
    		Console.WriteLine("I am a clsTblA!");
    	}
    }
    
    public class clsTblB : iTbl
    {
    	public int Property1 { get; set; }
    	public string Property2 { get; set; }
    	
    	public void WhatAreYou()
    	{
    		Console.WriteLine("I am a clsTblB!");
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		List<iTbl> tbls = new List<iTbl>()
    		{
    			new clsTblA(),
    			new clsTblB(),
    			new clsTblB(),
    			new clsTblA(),
    			new clsTblA()
    		};
    		
    		foreach (var tbl in tbls)
    		{
    			tbl.WhatAreYou();
    		}
    	}
    }
