    class HangmanGame
	{
		char[] charArray = {'h', 'a', 'n', 'g', 'm', 'a', 'n'};
		char[] found = {'*', '*', '*', '*', '*', '*', '*'};
		int guesses = 0;
		
		public void TestLetter(char userGuess)
		{
			bool foundLetter = false, alreadyInWord = false;
			for (int index = 0; index < charArray.Length; index++)
			{
				if(userGuess == found[index])
				{
					alreadyInWord = true;
					break;
				}
				else if(userGuess == charArray[index])
				{
					found[index] = charArray[index];
					foundLetter = true;
				}
			}
			if(alreadyInWord)
			{
				String s = "The letter " + userGuess + " was already in the word: " + new string(found) + ".";
				Console.WriteLine(s);
			}
			else if(foundLetter)
			{
				String s = "You guessed correctly: " + new string(found) + ".";
				Console.WriteLine(s);
			}
			else
			{
				guesses++;
			}
		}
    }
