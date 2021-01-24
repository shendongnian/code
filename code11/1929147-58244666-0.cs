    string inputUserName,inputPassword;
    // Loop for Username Input
    while(true)
    {
    	Console.WriteLine("Enter Username");
    	inputUserName = Console.ReadLine();
    	if(username.Contains(inputUserName))
    		break;
    	else
    		Console.WriteLine("Incorrect UserName");
    }
    while(true)
    {
    	Console.WriteLine("Enter Password");
    	inputPassword = Console.ReadLine();
    	var indexOfUserName = Array.IndexOf(username,inputUserName);
    	if(Int32.TryParse(inputPassword,out var value) && password[indexOfUserName] == value)
    		break;
    	else
    		Console.WriteLine("Incorrect Password");
    }
