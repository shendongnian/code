    void Main()
    {
    	var tester = new testing();
    	var runTimeOne = tester.optionOne();
    	runTimeOne.Dump();
    	var runTimeTwo = tester.optionTwo();
    	runTimeTwo.Dump();
    	var runTimeThree = tester.optionThree();
    	runTimeThree.Dump();
    }
    public class testing
    {
    	public String dataString = "part1.part2.part3";
    	public int numRuns = 1000000;
    
    	public TimeSpan optionOne()
    	{
    		var startTime = DateTime.Now;
    		
    		for(var i = 0; i < numRuns; i++)
    		{
    			string result = dataString.Split('.').Last<string>();
    		}
    		return (DateTime.Now - startTime);
    	}
    
    	public TimeSpan optionTwo()
    	{
    		var startTime = DateTime.Now;
    		
    		for(var i = 0; i < numRuns; i++)
    		{
    			string[] parts = dataString.Split('.');
    			string result = parts[parts.Length-1];
    			
    		}
    		return (DateTime.Now - startTime);
    	}
    	public TimeSpan optionThree()
    	{
    		var startTime = DateTime.Now;
    		
    		for(var i = 0; i < numRuns; i++)
    		{
    			string result = dataString.Substring(dataString.LastIndexOf('.')+1);
    		}
    		return (DateTime.Now - startTime);
    	}
    }
