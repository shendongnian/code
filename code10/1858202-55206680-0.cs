    while ((playerMove != "SCISSORS" && playerMove != "PAPER" && playerMove != "ROCK") || string.IsNullOrEmpty(playerMove))
                    {
                        Console.WriteLine("Please enter a valid command!");
                        playerMove = Console.ReadLine().ToUpper().Trim();
                        continue;
                    }
