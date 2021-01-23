    public AddWord(string word)
    {
    	if (String.IsNullOrEmpty(word))
    	{
    		throw new ArgumentException("word must contain values.", word);
    	}
    
    	var letter = word[0];
    	var child = Children.FirstOrDefault(x => x.Letter = letter);
    	
    	if (child == null)
    	{
    		//The child doesn't exist.  Create it.
    		child = new TrieNode(letter, false, new List<TrieNode>());
    	}
    		
    	if (word.Length > 1)
    	{
    		child.AddWord(word.Substring(1);
    	}
    	else
    	{
    		child.IsEndOfWord = true;
    	}
    }
