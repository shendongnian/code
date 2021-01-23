    string userInput="";
    while (userInput != "exit")
    {
        Console.Write("> ");
        userInput = Console.ReadLine().ToLower();
        switch (userInput)
        {
            case "exit": 
              break;
            case "help": 
            {
              DisplayHelp(); 
              break;
            }
            case "option1": 
            {
              DoOption1(); 
              break;
            }
            default: 
            {
              Console.WriteLine ("\"{0}\" is not a recognized command.  Type \"help\" for options.", userInput);
              break;
            }
        }
    }
