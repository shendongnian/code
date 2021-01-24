    // Dictionary declaration
    var userDictionary = new Dictionary<string,int>
    {
     	{ "BUL", 100 },
        { "GVL", 200 },
        { "UDF", 300 },
        { "RFT", 400 },
        { "WDR", 500 }
    };
    
    // Input and Condition Checks
    string inputUserName,inputPassword;
    // Loop for Username Input
    while(true)
    {
    	Console.WriteLine("Enter Username");
    	inputUserName = Console.ReadLine();
    	if(userDictionary.Keys.Contains(inputUserName))
    		break;
    	else
    		Console.WriteLine("Incorrect UserName");
    }
    while(true)
    {
    	Console.WriteLine("Enter Password");
    	inputPassword = Console.ReadLine();
    	if(Int32.TryParse(inputPassword,out var value) && userDictionary[inputUserName] == value)
    		break;
    	else
    		Console.WriteLine("Incorrect UserName");
    }
