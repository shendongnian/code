    public static class DecimalEx
    {
    	public static decimal Fix(this decimal value)
    	{
    		var x = value;
    		var i = 28;
    		while (i > 0)
    		{
    			var t = decimal.Round(x, i, MidpointRounding.AwayFromZero);
    			if (t != x)
    				return x;
    			x = t;
    			i--;
    		}
    		return x;
    	}
    }
