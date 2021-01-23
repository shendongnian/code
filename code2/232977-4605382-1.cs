    // somewhere to store the input
    string userInput="";
    // loop until the exit command comes in.
    while (userInput != "exit")
    {
        // display a prompt
        Console.Write("> ");
        // get the input
        userInput = Console.ReadLine().ToLower();
        // Branch based on the input
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
            // Give the user every opportunity to invoke your help system :)
            default: 
            {
              Console.WriteLine ("\"{0}\" is not a recognized command.  Type \"help\" for options.", userInput);
              break;
            }
        }
    }
