    void Main()
    {
    	string test = "StackOverflow     ";
    	int count = test.WhiteSpaceAtEnd();
    }
    
    public static class StringExtensions
    {
    	public static int WhiteSpaceAtEnd(this string self)
    	{
    		int count = 0;
    		int ix = self.Length - 1;
    		while (ix >= 0 && char.IsWhiteSpace(self[ix--]))
    			++count;
    
    		return count;
    	}
    }
