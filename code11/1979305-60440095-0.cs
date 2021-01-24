    int x = 0;
    while (x < 2)
    {
    	x++;
    
    	try
    	{
    		Console.WriteLine("inside try");
    
    		// test: can continue be used with a try block
    		continue;
    
    		Console.WriteLine("end of try");
    	}
    	catch(Exception e)
    	{
    		Console.WriteLine("err occurred");
    	}
    	finally
    	{
    		Console.WriteLine("inside finally");
    	}
    }
