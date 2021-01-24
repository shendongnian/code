    var running = true;
    while(running)
    {
         var input = Console.ReadLine().ToLower();
         var phrase = input.Sanitize(new List<string>() {".", ",", "?", "!", "'", "&", "%", "$", " "});
    
         if(phrase.IsPalindrome())
             Console.Writeline("Input was palindrome.");
    }
    
    public static string Sanitize(this string input, IList<string> punctuation) =>
         String.Join(String.Empty, input.Where(character => punctuation.Contains(character) == false));
	public static bool IsPalindrome(this string sentence)
	{
		for (int l = 0, r = sentence.Length - 1; l < r; l++, r--)
			if (sentence[l] != sentence[r])
				return false;
		return true;
	}
    public static void Close(string input) 
    {
        // Some logic to see if the application should stop.  
    }
