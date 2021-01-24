    static void Main(string[] args)
    {
    	try
    	{
    		string input;
    		while ((input = Console.ReadLine()) != "exit")
    		{
    			Console.WriteLine("I writed: " + input);
    		}
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}
    }
