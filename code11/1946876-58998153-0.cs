csharp
private static char GetGuess()
{ 
    while (true)
    { 
        Console.Write("Guess your letter: ");
        char.TryParse(Console.ReadLine().ToLower(), out char guess);
        if (char.IsLetter(guess))
        {
            return guess;
        }
        Console.Write("You have not entered a letter from a-z."); 
    }
}
