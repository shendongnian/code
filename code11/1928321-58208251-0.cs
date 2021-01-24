      string userInput;
      do
      {
        Console.WriteLine("Enter first number:");
        double operandFirst = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        double operandSecond = double.Parse(Console.ReadLine());
        double? result = null;
        bool isValid = true;
        do
        {
          Console.WriteLine();
          Console.WriteLine("Select the operation you want to perform:");
          Console.WriteLine("1 - Addition");
          Console.WriteLine("2 - Subtraction");
          Console.WriteLine("3 - Multiplication");
          Console.WriteLine("4 - Division");
          userInput = Console.ReadLine();
          switch ( userInput )
          {
            case "1":
              result = operandFirst + operandSecond;
              break;
            case "2":
              result = operandFirst - operandSecond;
              break;
            case "3":
              result = operandFirst * operandSecond;
              break;
            case "4":
              if ( operandSecond == 0 )
                Console.WriteLine("Can't divide by zero.");
              else
                result = operandFirst / operandSecond;
              break;
            default:
              Console.WriteLine("Unknown selected operation.");
              isValid = false;
              break;
          }
        }
        while ( !isValid );
        if ( result.HasValue )
          Console.WriteLine("Result = " + result);
        Console.WriteLine();
        Console.WriteLine("Retry?");
        Console.WriteLine("1 - Yes");
        Console.WriteLine("2 - No");
        userInput = Console.ReadLine();
        Console.WriteLine();
      }
      while ( userInput != "2" );
      Console.WriteLine("Bye bye.");
      Console.WriteLine("Press a key to exit.");
      Console.ReadKey();
