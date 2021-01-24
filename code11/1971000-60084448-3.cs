    static void Menu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Select what you want to do: ");
            Console.WriteLine("  1: Add a game");
            Console.WriteLine("  2: Show game rating");
            Console.WriteLine("  3: Exit");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.WriteLine();
            switch (userInput.KeyChar)
            {
                case '1':
                    // Code to add a game goes here (call AddGame() method, for example)
                    Console.Clear();
                    Console.WriteLine("Add a game was selected");
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                    break;
                case '2':
                    // Code to show a game rating goes here (call ShowRating(), for example)
                    Console.Clear();
                    Console.WriteLine("Show game rating was selected");
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                    break;
                case '3':
                    // Exit the menu
                    exit = true;
                    break;
            }
        }
    }
