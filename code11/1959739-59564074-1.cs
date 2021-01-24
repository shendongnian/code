	public static string ShowSequence(int n)
    {
        if (n == 0)
        {
            return n + "=";
        }
        if (n < 0)
        {
            return n + "<";
        }
		var strBuilder = new StringBuilder();
		strBuilder.Append(Enumerable.Range(0, n+1)
                                   .Select(x => x.ToString())
                                   .Aggregate((a, b) => a + "+" + b));
		strBuilder.Append($" = {(n*(n+1))/2}");
		return strBuilder.ToString();
    }
