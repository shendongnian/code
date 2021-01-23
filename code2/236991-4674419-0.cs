    public class Test
    {
    	static char ElementAtOrDefault(string value, int position)
    	{
    		return position >= value.Length ? default(char) : value[position];
    	}
    	static string parseStringLiteral(string value, ref int ChPosition)
    	{
    		StringBuilder Value = new StringBuilder();
    		char ChCurrent = ElementAtOrDefault(value, ++ChPosition);
    		while (ChCurrent != '"')
    		{
    			Value.Append(ChCurrent);
    			ChCurrent = ElementAtOrDefault(value, ++ChPosition);
    			if (ChCurrent == '"')
    			{
    				// "" sequence only acceptable
    				if (ElementAtOrDefault(value, ChPosition + 1) == '"')
    				{
    					Value.Append(ChCurrent);
    					// skip 2nd double quote
    					ChPosition++;
    					// move position next
    					ChCurrent = ElementAtOrDefault(value, ++ChPosition);
    				}
    			}
    			else if (default(Char) == ChCurrent)
    			{
    				// message: unterminated string
    				throw new Exception("ScanningException");
    			}
    		}
    		ChPosition++;
    		return Value.ToString();
    	}
    
    	public static void test(string literal)
    	{
    		Console.WriteLine("testing literal with " + literal.Length + 
    			" chars:\n" + literal);
    		try
    		{
    			int pos = 0;
    			string res = parseStringLiteral(literal, ref pos);
    			Console.WriteLine("Parsed " + res.Length + " chars:\n" + res);
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine("Error: " + ex.Message);
    		}
    		Console.WriteLine();
    	}
    
    	public static int Main(string[] args)
    	{
    		test(@"""Hello Language Design""");
    		test(@"""Is there any problems with the """"strings""""?""");
    		test(@"""v#:';?325;.<>,|+_)""(*&^%$#@![]{}\|-_=""");
    		return 0;
    	}
    }
