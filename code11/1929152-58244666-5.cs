    public string ReadFromUserTillTrue(string promptMessage,string errorMessage,Func<string,bool> validator)
    {
    	var input = string.Empty;
    	while(true)
    	{
    		Console.WriteLine(promptMessage);
    		input = Console.ReadLine();
    		if(validator(input))
    			break;
    		else
    			Console.WriteLine(errorMessage);
    	}
    	return input;
    }
 
