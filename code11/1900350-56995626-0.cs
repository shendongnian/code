    static void Main(string[] args)
    {
        var lives = 10;
        var correctGuesses = new List<char>();
        var word = "green";
        while (true)
        {
            Console.WriteLine("Guess a letter? ");
            // deliberatly just check for 1 character for simplicity reasons
            var input = Console.ReadLine()[0];
            // if already guessed give a chance to the user to retry
            if (correctGuesses.Contains(input))
            {
                Console.WriteLine("Letter already guessed");
            }
            else
            {
                // if the word contains the letter
                if (word.Contains(input))
                {
                    // add as a correct guess
                    correctGuesses.Add(input);
                    Console.WriteLine("Letter found");
                }
                else
                {
                    // letter dont exist remove a life
                    lives--;
                    Console.WriteLine("Letter not found");
                }
            }
            // check if the user still have lives
            if (lives == 0)
            {
                Console.WriteLine("You lost");
                break;
            }
            // check if the amount of distinct character in the word match 
            // the amount found. This mean the word is completly guessed
            else if (word.Distinct().Count() == correctGuesses.Count())
            {
                Console.WriteLine("You won you found the word");
                break;
            }
        }
        Console.ReadKey();
    }
