    List<string> parsedTokens = new List<String>();
    string[] tokens = myString.split(' ');
    for(int i = 0; i < tokens.Length; i++)
    {
        // We need to deal with the special case of the last item, 
        // or if the following item does not contain a colon.
        if(i == tokens.Length - 1 || tokens[i+1].IndexOf(':' > -1)
        {
            parsedTokens.Add(tokens[i]);
        }
        else
        {
            // This bit needs to be refined to deal with values with multiple spaces...
            parsedTokens.Add(tokens[i] + " " + tokens[i+1]);
        }
    }
