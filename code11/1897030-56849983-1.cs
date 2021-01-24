      // Let's organize all valid input as a collection for better
      // readability and better maintenance
      HashSet<string> validInputs = new HashSet<string>() {
        "+", "-", "*", "/",
      };
      // Keep asking...
      while (true) {
        // $"...{string.Joi(...)}..." let's be nice and let user know 
        // which operations are supported: "+, -, *, /"
        Console.Write($"What Operation? ({string.Join(", ", validInputs)}): "); 
        // Trim() - let's be nice and tolerate leading / trailing spaces
        string input = Console.ReadLine().Trim(); 
        // ... until user provides a valid input 
        if (validInputs.Contains(input)) {        
          op = input;
          break;
        }
        Console.WriteLine("Enter a valid operation!!!"); 
      }
