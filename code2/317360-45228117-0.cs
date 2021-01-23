    public static string ReadToString(StreamReader sr, string splitString)
    {        
        char nextChar;
        StringBuilder line = new StringBuilder();
        int matchIndex = 0;
        
        while (sr.Peek() > 0)
        {               
            nextChar = (char)sr.Read();
            line.Append(nextChar);
            if (nextChar == splitString[matchIndex])
            {
            	if(matchIndex == splitString.Length - 1)
            	{
            		return line.ToString().Substring(0, line.Length - splitString.Length);
            	}
            	matchIndex++;
            }
	        else
	        {
	            matchIndex = 0;
            }
        }
    
        return line.Length == 0 ? null : line.ToString();
    }
