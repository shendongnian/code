       while (true) {
         if (0 == option) {
           ConsoleKeyInfo TurnChoice = Console.ReadKey();
           if (TurnChoice.key == ConsoleKey.M) 
             option = 2;
           else if (TurnChoice.key == case ConsoleKey.S)
             option = 1;
         } 
         if (1 == option) {
           ...
         }
         else if (2 == option) { // drop "else" if option can be changed within if (option == 1)
           ...
         } 
       }
