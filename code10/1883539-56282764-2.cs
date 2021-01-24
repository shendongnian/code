    string input = "";
    bool success = false;
    while (!success) 
    {
    	Console.Write("Please input the two numbers you wish to use seperated by a space: ");
    	input = Console.ReadLine();
    
    	var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    	if (values.Length != 2 || !values.All(v => int.TryParse(v, out int value))
    	{
    		Console.WriteLine($"You entered \"{input}\" You did not enter two numbers separated by a space, please try again.");
    	}
    	else 
    	{
    		success = true;
    	}
    }
