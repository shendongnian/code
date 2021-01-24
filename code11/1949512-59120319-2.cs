    class Program
    {
    	static void Main(string[] args)
    	{
    		Math m = new Math();
    
    
    		// Optional loop, if you want to keep the application running until the user close it.
    		while(true)
    		{
    			var result = m.DoingMath();
    
    			Console.WriteLine(result);
    
    			Console.WriteLine();
    
    			Console.WriteLine("Do you want to continue ? [Yes/No]");
    
    			var doContinue = Console.ReadLine();
    
    			if (doContinue.ToLower().Trim().Equals("no"))
    				break;
    		}
    
    	}
    }
