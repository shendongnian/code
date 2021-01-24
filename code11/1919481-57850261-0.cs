    public static int ReadInteger(string prompt, 
                                  Func<int, bool> validation = null, 
                                  string validationMessage = null) {
      int result;
      while (true) {   
        if (!string.IsNullOrEmpty(prompt))
          Console.WriteLine(prompt);
        string input = Console.ReadLine();
        if (!int.TryParse(input, out result)) 
          Console.WriteLine("Sorry, your input is not a valid integer value. Please, try again."); 
        else if (validation != null && !validation(result)) 
          Console.WriteLine(string.IsNullOrEmpty(validationMessage)
            ? "Sorry the value is invalid. Please, try again"
            : validationMessage);
        else
          return result;
       }
    }
