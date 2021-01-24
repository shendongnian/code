    string position, name, team;
    Console.Write("Enter position: ");
    position = Console.ReadLine();
    if(position.ToLower() == "player")
    {
        int scoreCount = 0;
        Console.Write("Enter the score count: ");
        scoreCount = int.Parse(Console.ReadLine());
        Console.Write("Enter team: ");
        team = Console.ReadLine();    
        if(scoreCount < 20)
        {
            // ...
        }
        else
        {
            // ...
        }
    }
    else if (position.ToLower() == "referee")
    {
        int totalWhistles = 0;
        // ...
    }
