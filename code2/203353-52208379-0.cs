    public static int Search(this String text, params string[] pValores)
    {
    	int _ret = 0;
    	try
    	{
    		var Palabras = text.Split(new char[] { ' ', '.', '?', ',', '!', '-', '(', ')', '"', '\''  }, 
    			StringSplitOptions.RemoveEmptyEntries);
    		foreach (string word in Palabras)
    		{
    			foreach (string palabra in pValores)
    			{
    				if (Regex.IsMatch(word, string.Format(@"\b{0}\b", palabra), RegexOptions.IgnoreCase))
    				{
    					_ret++;
    				}
    			}
    		}				
    	}
    	catch { }
    	return _ret;
    }
