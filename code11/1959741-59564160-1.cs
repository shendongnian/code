	public static string ShowSequence(int n)
	{
		if (n == 0)
		{
			return n + " = 0";
		}
		if (n < 0)
		{
			return n + " < 0";
		}
		// generate all numbers from 0 to n. Takes n+1 steps. 
		var enumeration = Enumerable.Range(0, n+1);
		
		var plusOperatorConcatenation = String.Join(" + ",  enumeration ) ;
		
		return plusOperatorConcatenation + " = " + enumeration.Sum();
	}
