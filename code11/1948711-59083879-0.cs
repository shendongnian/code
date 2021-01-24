     public static string GetInput(Game game)
     {
         do
         {
             string input;
             WriteLine("Please enter your choice: Rock - 1, Paper - 2, Scissors - 3");
             input = ReadLine();
             return input;
         }
         while (game.win < 4 || game.lose < 4 || game.usermoney == 0);
     }
