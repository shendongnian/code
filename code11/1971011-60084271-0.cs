    string nameCorrect;
    string playerName;
    int attempt = 0;
    do
    {
        Console.WriteLine(attempt > 0
            ? "Apologies, what is the correct name?"
            : "What is your name?");
        playerName = Console.ReadLine();
        Console.WriteLine("Is {0} correct?", playerName);
        nameCorrect = Console.ReadLine();
        attempt++;
    } while(nameCorrect == "No");
    if(nameCorrect == "Yes")
    {
      Console.WriteLine("Great, lets move on.");
    }
     
    Console.ReadKey();
