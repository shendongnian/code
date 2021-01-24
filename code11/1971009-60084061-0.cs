`
        string nameCorrect;
        string playerName;
        string namePrompt = "What is your name?";
        do
        {
            Console.WriteLine(namePrompt);
            if (namePrompt == "What is your name?") namePrompt = "Apologies, what is the correct name?"
            playerName = Console.ReadLine();
            Console.WriteLine("Is {0} correct?", playerName);
            nameCorrect = Console.ReadLine();
        } while(nameCorrect == "No");
        if(nameCorrect == "Yes")
        {
            Console.WriteLine("Great, lets move on.");
        }
        Console.ReadKey();
`
