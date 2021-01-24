    class Program
    {
        static void Main(string[] args)
        {
            bool found = false;
            string originalWord = "test";
            char[] word = originalWord.ToCharArray();
            char[] asteriskedWord = new string('*', word.Length).ToCharArray();
            while (found == false)
            {
                Console.WriteLine(asteriskedWord);
                string input = Console.ReadLine();
                if (input.Length != 1)
                {
                    Console.WriteLine("Your input can be only one char.");
                }
                else
                {
                    char c = char.Parse(input);
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == c)
                        {
                            asteriskedWord[i] = c;
                            word[i] = '*';
                            int missingCharsAmount = asteriskedWord.Count(x => x == '*');
                            Console.WriteLine("Correct, missing " + missingCharsAmount + " chars.");
                            if (missingCharsAmount == 0)
                            {
                                found = true;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
