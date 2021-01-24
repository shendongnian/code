    public static class StringExtensions
    {
    	public static string GetLastDigits( this string source, int count )
    	{
    		return new string( source
    			.Where(ch => Char.IsDigit(ch))
    			.Reverse()
    			.Take(count)
    			.Reverse()
    			.ToArray());
    	}
    }
