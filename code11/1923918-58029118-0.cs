    public static void AverageMaker()
    {
        Console.WriteLine("-----Enter score---");
        scoreString = Console.ReadLine();
        scoreBool = int.TryParse(scoreString, out score); //This was missing
    }
