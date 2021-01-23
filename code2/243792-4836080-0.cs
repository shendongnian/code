    public void Test()
    {
    	var separators = new[] { ' ', '\t', '\r', '\x00a0', '\x0085', '?', ',', '.', '!' };
    
    	var input = "Test  string, news112!  news \n next, line! error in error word";			
    	var tokens = new Queue<string>(input.Split(separators, StringSplitOptions.RemoveEmptyEntries));
    
    	string currentWord = null;
    
    	while (tokens.Any())
    	{
    		currentWord = tokens.Dequeue();
    		if (currentWord.All(c => Char.IsLetterOrDigit(c)))
    		{
    			if (!CheckSpell(currentWord))
    			{
    				break;
    			}
    		}
    	}
    }
    
    public bool CheckSpell(string word)
    {
    	return word != null && word.Length > 0 && word[0] != 'e';
    }
