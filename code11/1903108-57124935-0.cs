    public string ReplaceWords(string input, Dictionary<string, string> replacements)
    {
    	var builder = new StringBuilder();
    	int wordStart = -1;
    	int wordLength = 0;
    	for(int i = 0; i < input.Length; i++)
    	{
    		if(char.IsWhiteSpace(input[i]))
    		{
    			if(wordStart >= 0)
    			{
    				var word = input.Substring(wordStart, wordLength);
    				if(replacements.TryGetValue(word, out var replace))
    				{
    					builder.Append(replace);
    				}
    				else
    				{
    					builder.Append(word);
    				}
    			}
    			
    			wordStart = -1;
    			wordLength = 0;
    			builder.Append(input[i]);
    		}
    		else
    		{
    			if(wordStart == -1) wordStart = i;
    			wordLength++;
    		}
    	}
    	
    	if(wordStart == 0)
    	{
    		return replacements.TryGetValue(input, out var replace) ? replace : input;
    	}
    	
    	if(wordStart > 0)
    	{
    		var word = input.Substring(wordStart, wordLength);
    		if(replacements.TryGetValue(word, out var replace))
    		{
    			builder.Append(replace);
    		}
    		else
    		{
    			builder.Append(word);
    		}
    	}
    	
    	return builder.ToString();
    }
