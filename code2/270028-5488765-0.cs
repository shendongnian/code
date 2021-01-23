    public static IEnumerable<int> FindIndex(int input)
    {
    	var power = 0;
    	while (input > 0)
    	{
    		var digit = input % 2;
    		if (digit == 1)
    		{
    			yield return (int)Math.Pow(2, power);
    		}
    		input /= 2;
    		power++;
    	}
    }
