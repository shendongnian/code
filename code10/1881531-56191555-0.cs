            string alt;
            bool firstRun = true;
            do
            {
                if (firstRun)
                {
                    firstRun = false;
                    GameLogic();
                }
                
                Console.WriteLine("Play again?");
                Console.WriteLine("[Y]es | [N]o");
                alt = Console.ReadLine();
                alt.ToLower();
                if (alt == "Y" || alt == "y")
                {
                    Console.Clear();
                    GameLogic();
                }
                else if (alt == "N" || alt == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input!");             
                }
            } while (alt != "N" || alt != "n");
            Console.WriteLine("\nPress any key to quit...");
            Console.ReadKey();
