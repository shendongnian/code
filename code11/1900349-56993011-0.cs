        private static bool IsCorrectGuess(char input, string actualWord)
        {
            return actualWord.Contains(input);
        }
        private static void WriteCorrectGuesses(ICollection<char> correctGuesses, string randomWord)
        {
            char[] charFromString = randomWord.ToCharArray();
            for (var i = 0; i < randomWord.Length; i++)
            {
                charFromString[i] = '*';
                if (correctGuesses.Contains(randomWord[i]))
                    charFromString[i] = randomWord[i];
            }
            Console.WriteLine(charFromString);
        }
        private static string GeneratingRandomWords()
        {
            var r = new Random();
            var words = new List<string>
            {
                /*"Cat", "Dog", "Eagle", "Lion", "Shark",*/ "Green"
            };
            return words[r.Next(0, words.Count)];
        }
        private static char Input()
        {
            return char.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        }
        private static void Main(string[] args)
        {
            string randomWord = GeneratingRandomWords();
            var correctGuesses = new List<char>();
            WriteCorrectGuesses(correctGuesses, randomWord);
            var lives = 10;
            var correct = 0;
            //bool won = true;
            while (true)
            {
                Console.WriteLine("Write a char");
                char input = Input();
                if (IsCorrectGuess(input, randomWord))
                {
                    // correct letter 
                    int score = randomWord.ToCharArray().Count(item => item == input);
                    for (var i = 0; i < score; i++)
                    {
                        correctGuesses.Add(input);
                        correct++;
                    }
                    WriteCorrectGuesses(correctGuesses, randomWord);
                    if (correctGuesses.Count == randomWord.Length)
                    {
                        Console.WriteLine("You won the word is: {0}", randomWord);
                        Console.Read();
                        break;
                    }
                    Console.WriteLine("Next");
                }
                else
                {
                    // wrong letter
                    Console.WriteLine($"Try another one. You still have {lives} to try.");
                    lives--;
                }
                if (lives == 0)
                {
                    Console.WriteLine("You lose sorry, try again next time ");
                    break;
                }
            }
        }
