    static void Main(string[] args)
    {
    	try
    	{
    		string line;
    		while ((line = Console.ReadLine()) != "exit")
    		{
    			Console.WriteLine("I writed: " + line);
    			string input = Console.ReadLine().ToString();
    			Console.WriteLine("I writed: " + input);
    		}
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}
    }
