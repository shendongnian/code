	public static void FindSandy(params string[] ocean)
	{
		for (int i = 0; i < ocean.Length; i++)
		{
        	if (ocean[i] == "Sandy")
       		{
           		Console.WriteLine("We found Sandy on position {0}", i);
                // Found, you can return from method.
				return; 
		    }
    	}
        
        // Not found, write the 'not found' message.
		Console.WriteLine("He was not here");
	}
