`
        static void PlayHangMan(string wordToGuess, int numberOfGuesses)
        {
            try
            {
                int counter = 0;
                bool victory = false;
                var charArray = wordToGuess.ToCharArray();
                var found = new char[charArray.Length];
                for (int i = 0; i < charArray.Length; i++)
                {
                    found[i] = '*';
                }
                string hiddenWord = string.Empty;
                foreach (char character in charArray)
                {
                    hiddenWord = hiddenWord + "*";
                }
                while (counter < numberOfGuesses)
                {
                    Console.Write($"(Guess left: {numberOfGuesses - counter}) Enter a letter in a word: {hiddenWord} > ");
                    // Wait for user input
                    var userGuess = Console.ReadKey().KeyChar;
                    
                    hiddenWord = string.Empty;
                    Console.WriteLine();
                    for (int index = 0; index < charArray.Length; index++)
                    {
                        if (charArray[index] == userGuess)
                        {
                            found[index] = userGuess;
                            hiddenWord = hiddenWord + userGuess;
                        }
                        else
                        {
                            hiddenWord = hiddenWord + found[index];
                        }
                    }
                    counter++;
                    if (!found.Any(f => f == '*'))
                    {
                        Console.WriteLine($"You won! Word: {hiddenWord}");
                        victory = true;
                        break;
                    }
                }
                if (!victory)
                    Console.WriteLine("You are out of guesses.");
                Console.Read();
            }
            catch (Exception ex)
            {
                var m = ex.Message;
            }
        }
`
[![enter image description here][1]][1]
or
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/1ubaB.jpg
  [2]: https://i.stack.imgur.com/0iUUQ.jpg
