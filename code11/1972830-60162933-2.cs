            Console.Write("Enter position: ");
            position = Console.ReadLine();
            // earlier this was inside the if condition.
            Console.Write("Enter the score count: ");
            scoreCount = int.Parse(Console.ReadLine());
    
            if ((position == "Player" || position == "player") && scoreCount < 20)
            {
                Console.Write("Enter team: ");
                team = Console.ReadLine();
                //scoreCount = int.Parse(Console.ReadLine()); removed from here added on top of if conditon. 
                Console.WriteLine("Average job {0}, your score is {1}", team, scoreCount);
            }
            else if ((position == "Player" || position == "player") && scoreCount > 20)
            {
                Console.Write("Enter team: ");
                team = Console.ReadLine();
                Console.WriteLine("Superb job {0}! Your score count is {1}", team, scoreCount);
            }
            else if (position == "referee" || position == "Referee")
            {
                Console.Write("Enter total whistles: ");
                totalWhistles = int.Parse(Console.ReadLine());
                Console.WriteLine("You blowed {0} whistles", totalWhistles);
            }
  
