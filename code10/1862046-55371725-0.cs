       while (true) {
         if (option == 0) {
           ConsoleKeyInfo TurnChoice = Console.ReadKey();
           if (TurnChoice.key == ConsoleKey.M) 
             option = 2;
           else if (TurnChoice.key == case ConsoleKey.S)
             option = 1;
         } 
         if (option == 1) {
           ...
         }
         else if (option == 2) { // drop "else" if option can be changed within if (option == 1)
           ...
         } 
       }
