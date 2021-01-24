    static void SearchAccount()
    {
      string[] allLinesFromFile = File.ReadAllLines("12.txt");
      string userCheck = "n";
      while (userCheck != "n")
      {  
        bool isLineFound = false;
        Console.SetCursorPosition(10, 9);
        Console.WriteLine("Account Number:");
        Console.SetCursorPosition(25, 9);
        string userInput = Console.ReadLine();
    
        for (var lineIndex = 0; lineIndex < allLinesFromFile.Length; lineIndex++)
        {
          string currentLine = allLinesFromFile[lineIndex];
          if (currentLine.Contains(userInput))
          {
            Console.WriteLine("Account details are found");
            Console.WriteLine(userInput);
    
            // TODO: Use another for-loop to return the previous six lines 
            // using the lineIndex and the allLinesFromFile array
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("Check another account? y/n");
            Console.SetCursorPosition(10, 21);
            userCheck = Console.ReadLine();
            isLineFound = true;
            break;
          }          
        }
        if (!isLineFound)
        {    
          Console.SetCursorPosition(10, 19);
          Console.WriteLine("Account not found!");
          Console.SetCursorPosition(10, 20);
          Console.WriteLine("Check another account? y/n");
          Console.SetCursorPosition(10, 21);
          userCheck = Console.ReadLine();
        }
      }
    
      Console.Clear();
      mainMenu();
    }
