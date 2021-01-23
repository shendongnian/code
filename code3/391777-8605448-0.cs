    public static class ReplaceWordNoRegex
    {
    	private static bool IsWordChar(char c)
    	{
    		return Char.IsLetterOrDigit(c) || c == '_';
    	}
    
    	public static string ReplaceFullWords(this string s, string oldWord, string newWord)
    	{
    		if (s == null) {
    			return null;
    		}
    		int startIndex = 0;
    		while (true) {
    			int position = s.IndexOf(oldWord, startIndex);
    			if (position == -1) {
    				return s;
    			}
    			int indexAfter = position + oldWord.Length;
    			if ((position == 0 || !IsWordChar(s[position - 1])) && (indexAfter == s.Length || !IsWordChar(s[indexAfter]))) {
    				s = s.Substring(0, position) + newWord + s.Substring(indexAfter);
    				startIndex = position + newWord.Length;
    			} else {
    				startIndex = position + oldWord.Length;
    			}
    		}
    	}
    }
