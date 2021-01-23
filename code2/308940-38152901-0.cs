      public static string WhiteSpaceToSingleSpaces(string input)
      {
        if (input.Length < 2) 
            return input;
    
        StringBuilder sb = new StringBuilder();
    
        input = input.Trim();
        char lastChar = input[0];
        bool lastCharWhiteSpace = false;
    
        for (int i = 1; i < input.Length; i++)
    	{
            bool whiteSpace = char.IsWhiteSpace(input[i]);
    
            //Skip duplicate whitespace characters
            if (whiteSpace && lastCharWhiteSpace)
                continue;
    
            //Replace all whitespace with a single space.
            if (whiteSpace)
                sb.Append(' ');
            else
                sb.Append(input[i]);
    
            //Keep track of the last character's whitespace status
            lastCharWhiteSpace = whiteSpace;
    	}
    
        return sb.ToString();
      }
