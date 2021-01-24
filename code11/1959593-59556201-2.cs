    while(++nOfguesses <= 3 && number != guessedNumber)
    {
        var guess = Console.ReadLine();
        var guessedNumber = Convert.ToInt16(guess);
        if (number != guessedNumber)
        {
            Console.WriteLine("Try again.");
        }
        else
        {
            Console.WriteLine("You got it!");
        }
    }
    Console.WriteLine("Game over.");
