    public static bool ContainsAllWords(this string input, string search)
    {
        foreach (string word in search.split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
    	    if (!input.Contains(word))
    	        return false;
        }
        return true;
    }
