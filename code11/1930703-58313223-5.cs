    static void Main(string[] args)
    {
        var randomNumber = new Random().Next(1, 101);
        var maxAttempts = 5;
        var guess = 0;
        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            Console.WriteLine($"You have {maxAttempts - attempt} " + 
                $"out of {maxAttempts} attempts remaining.");
            guess = GetIntFromUser("Please enter your guess (1 - 100): ", 
                i => i > 0 && i < 101);
            if (guess == randomNumber)
            {
                Console.WriteLine($"You have won in {attempt + 1} tries!");
                break;
            }
            Console.WriteLine(GetDifferenceString(guess, randomNumber, 1, 100));
        }
        if (guess != randomNumber)
        {
            Console.WriteLine("Sorry, you lose! The number was: " + 
                $"{randomNumber}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
