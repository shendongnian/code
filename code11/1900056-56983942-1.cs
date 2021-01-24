    // Let's be nice and show expected user response - 1 or 2
    Console.WriteLine("Select an action to perform (1, 2)\n");
    
    int n1;
    
    while (true) {
      // If user input is a valid i.e.
      //   1. Input is valid integer - int.TryParse returns true
      //   2. User input is either 1 or 2
      // we break the loop and start business logic; otherwise keep asking  
      if (int.TryParse(Console.ReadLine(), out n1) && ((n1 == 1) || (n1 == 2)))
        break;
    
      // Again, let's be nice and help user
      Console.WriteLine("Insert a valid method (either 1 or 2)\n"); 
    }
    
    Console.WriteLine(n1);
    Console.ReadKey();
