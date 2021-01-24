	   public static bool IsPalindrome(string word)
        {
            string testWord = word;
			for(int i = 0; i < word.Length/2; i++)
			{
				if(char.ToLower(testWord[i]) != char.ToLower(testWord[testWord.Length - i - 1]))
				   return false;
			}
            return true;
        }
