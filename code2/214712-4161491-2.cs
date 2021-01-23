    // Initialise the result to nothing.
    string result = string.Empty;
    
    // Prompt for input.
    Console.WriteLine("Please enter your 10-digit phone number: ");	
    
    do
    {
    	string input = Console.ReadKey().KeyChar.ToString();
    
    	// Replace any characters that are not numbers with the empty string (remove them).
    	result += Regex.Replace(input, "[^0-9]", string.Empty);			
    }
    while (result.Length != 10);
    
    // Do something with the result.
    Console.WriteLine("You typed: '{0}'.", result);
