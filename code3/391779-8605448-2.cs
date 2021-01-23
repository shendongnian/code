    public static string ReplaceFullWords(this string s, string oldWord, string newWord)
    {
    	if (s == null) {
    		return null;
    	}
    	int startIndex = 0; // Where we start to search in s.
    	int copyPos = 0; // Where we start to copy from s to sb.
    	var sb = new StringBuilder();
    	while (true) {
    		int position = s.IndexOf(oldWord, startIndex);
    		if (position == -1) {
    			if (copyPos == 0) {
    				return s;
    			}
    			if (s.Length > copyPos) { // Copy last chunk.
    				sb.Append(s.Substring(copyPos, s.Length - copyPos));
    			}
    			return sb.ToString();
    		}
    		int indexAfter = position + oldWord.Length;
    		if ((position == 0 || !IsWordChar(s[position - 1])) && (indexAfter == s.Length || !IsWordChar(s[indexAfter]))) {
    			sb.Append(s.Substring(copyPos, position - copyPos)).Append(newWord);
    			copyPos = position + oldWord.Length;
    		}
    		startIndex = position + oldWord.Length;
    	}
    }
