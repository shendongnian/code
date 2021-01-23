    do
                {
                    Console.Write("\nEnter your move: ");
                    move = Console.ReadLine();
    
    
                    switch (move)
                    {
                        case "r":
                            Console.Write("\nYou have reloaded, press enter for Genius");
                            Console.ReadLine();
                            break;
                        case "s":
                            Console.Write("\nYou have shielded, press enter for Genius");
                            Console.ReadLine();
                            break;
                        case "f":
                            Console.Write("\nYou have fired, press enter for Genius");
                            Console.ReadLine();
                            break;
                        default:
                            Console.Write("\nInvalid move, try again\n\n");
                            break;
                    }
    
    
                }
     while (move == "r" || move == "s" || move == "f");
