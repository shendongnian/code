                int totalWhistles = 0, scoreCount = 0;
    
                string position = "", team = "";
    
                Console.Write("Enter position: ");
                position = Console.ReadLine();
    
                if ((position.ToLower() == "player" ))
                {
                    Console.Write("Enter the score count: ");
                    scoreCount = int.Parse(Console.ReadLine());
    
                    Console.Write("Enter team: ");
                    team = Console.ReadLine();
                    if(scoreCount > 20)
                        Console.WriteLine("Superb job {0}! Your score count is {1}", team, scoreCount);
                    else
                        Console.WriteLine("Average job {0}! Your score count is {1}", team, scoreCount);
                }
                else if (position.ToLower() == "referee")
                {
                    Console.Write("Enter total whistles: ");
                    totalWhistles = int.Parse(Console.ReadLine());
    
                    Console.WriteLine("You blowed {0} whistles", totalWhistles);
                }
    
                Console.ReadLine();
