    public static int CountWords(string test)
    {
      int count = 0;
      bool inWord = false;
    
      foreach (char t in test)
      {
        if (char.IsWhiteSpace(t))
        {
          inWord = false;
        }
        else
        {
    	  if (!inWord) count++;
    	  inWord = true;
    	}
      }
      return count;
    }
