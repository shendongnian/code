    char[] guessed = new char[26];
    char guess;
    char playAgain;
    
    int amountMissed = 0, index = 0;
            
    do
    {
    			
        char[] word = RandomLine().ToCharArray();  // Change :This needs to be inside the loop so that new random word could be selected user selects to continue the game
    	char[] testword = new string('*',word.Length).ToCharArray();  // Change : Reordered initilization of word and testword so that we could generate testword with same length as original
        char[] copy = word;
    			
        Console.WriteLine(testword);
        Console.WriteLine("I have picked a random word on animals");
        Console.WriteLine("Your task is to guess the correct word");
        
        while (!testword.SequenceEqual(word)) // Change : Comparison of arrays
        {
    			
                Console.Write("Please enter a letter to guess: ");
    
                guess = char.Parse(Console.ReadLine());
                bool right = false;
                for (int j = 0; j < copy.Length; j++)
                {
                   if (copy[j] == guess)
                   {
                     Console.WriteLine("Your guess is correct.");
                     testword[j] = guess;
                     guessed[index] = guess;
                     index++;
                     right = true;
                   }
                 }
                 if (right != true)
                 {
                    Console.WriteLine("Your guess is incorrect.");
                    amountMissed++;
                 }
                 else
                 {
                    right = false;
                 }
                 Console.WriteLine(testword);
    
              }
              Console.WriteLine($"The word is {copy}. You missed {amountMissed} times.");
    
              Console.WriteLine("Do you want to guess another word? Enter y or n: ");
              playAgain = char.Parse(Console.ReadLine());
            } while (playAgain == 'y' || playAgain == 'Y');
    
            Console.WriteLine("Good-Bye and thanks for playing my Hangman game.");
