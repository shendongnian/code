    public static class SqlFunctions
    {
    	[DbFunction("DIFFERENCE", "")]
    	public static int? Difference(string s1, string s2)
    		=> throw new NotSupportedException();
    }
