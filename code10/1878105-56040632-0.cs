            string secretWord = "Catatonic";
            string guess = "";
            int guessCount = 0;
            int guessLimit = 3;
            bool outOfGuesses = false;
            Console.WriteLine("Guess the secret word: ");
            do
            {
                guess = Console.ReadLine();
                guessCount++;
                if (string.Equals(guess, secretWord, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(guessCount == 1 ? "You win!" : "You're a winner!");
                    break;
                }
                if (guessCount < guessLimit)
                {
                    Console.WriteLine("Wrong answer, try again: ");
                }
                else
                {
                    outOfGuesses = true;
                }
            } while (!outOfGuesses);
            if (outOfGuesses)
            {
                Console.WriteLine("You're out of guesses mate");
            }
