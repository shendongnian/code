    public static object CheckValue(string type)
    {
    	// Get the type from string
    	Type t = Type.GetType(type);
    
    	// Used in the loop
    	bool isConvertable = false;
    
    	// Initialize object
    	object convertInput = null;
    
    	Console.Write("Enter a value: ");
    	while (isConvertable == false)
    	{
    		try
    		{
    			string input = Console.ReadLine();
    			convertInput = Convert.ChangeType(input, t);
    			isConvertable = true;
    		}
    		catch (Exception)
    		{
                // If the conversion throw an exception, it means that it has an incorrect type
    			Console.Write("The value is incorrect, enter new value: ");
    		}
    	}
        
        // Just for output purpose
        Console.WriteLine("Value has the correct type!");
    	return convertInput;
    }
