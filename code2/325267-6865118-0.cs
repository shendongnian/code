    private static int CountAbsoluteDigits(double p) {
    	int absolute = (int)Math.Abs(p);
    	if (0 == absolute)
    		return 0;
    	else
    		return absolute.ToString().Length;
    }
...
    var length = CountAbsoluteDigits(12.324654);
