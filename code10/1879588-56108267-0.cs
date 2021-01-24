    int value = 0; // initialization : let compiler be happy
    
    // keep on asking until valid input is provided
    while (true) {
      Console.WriteLine("Please, input an integer value");
    
      // read input and try to parse it
      if (int.TryParse(Console.ReadLine(), out value))
        break; // break, if input is a valid integer
    
      // int.TryParse returned false - parsing failed - let user know it
      Console.WriteLine("Sorry, it's not an integer value. Please, try again.");
    }
    // from now on, value contains a integer input from user
