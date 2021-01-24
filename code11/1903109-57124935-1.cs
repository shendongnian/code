    public string ReplaceWords(string input, Dictionary<string, string> replacements)
    {
    	var builder = new StringBuilder();
    	int wordStart = -1;
    	int wordLength = 0;
    	for(int i = 0; i < input.Length; i++)
    	{
    		// If the current character is white space check if we have a word to replace
    		if(char.IsWhiteSpace(input[i]))
    		{
    		    // If wordStart is not -1 then we have hit the end of a word
    			if(wordStart >= 0)
    			{
    			    // get the word and look it up in the dictionary
    				// if found use the replacement, if not keep the word.
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
    			
    			// Make sure to reset the start and length
    			wordStart = -1;
    			wordLength = 0;
    			
    			// append whatever whitespace was found.
    			builder.Append(input[i]);
    		}
    		// If this isn't whitespace we set wordStart if it isn't already set
    		// and just increment the length.
    		else
    		{
    			if(wordStart == -1) wordStart = i;
    			wordLength++;
    		}
    	}
    	    	
    	// If wordStart is not -1 then we have a trailing word we need to check.
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
    	
    	return builder.ToString();
    }
