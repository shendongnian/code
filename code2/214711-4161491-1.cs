    // Initialise the result to nothing.
    string result = string.Empty;
    
    do
    {
    	// Prompt for input.
    	Console.WriteLine("Please enter your 10-digit phone number: ");
    	
    	// Read the response.
    	string input = Console.ReadLine();
    
    	// Replace any characters that are not numbers with the empty string (remove them).
    	result = System.Text.RegularExpressions.Regex.Replace(input, "[^0-9]", string.Empty);
    }
    while (result.Length != 10);
    
    // Initialise the result to nothing.
    Console.WriteLine("You typed: '{0}'.", result);
