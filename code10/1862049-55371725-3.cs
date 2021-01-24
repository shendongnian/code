    while(true) {
    
      switch(option) {
    
        case 0:
           ConsoleKeyInfo TurnChoice = Console.ReadKey();
    
           switch(TurnChoice.key) 
           {
    
           case ConsoleKey.M
             option = 2;
             continue;        // <- continue instead of break
     
           case ConsoleKey.S
             option = 1;
             continue;        // <- continue instead of break
           }
           ...
