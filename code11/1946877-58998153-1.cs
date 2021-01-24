csharp
private static char GetGuess()
{ 
    while (true)
    { 
        Console.Write("Guess your letter: ");
        if (char.TryParse(Console.ReadLine().ToLower(), out char guess) && 
            char.IsLetter(guess))
        {
            return guess;
        }
        Console.Write("You have not entered a letter from a-z."); 
    }
}
