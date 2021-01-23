    public static int getDecimalCount(double dVal, string sVal, string culture, char sep)
    {
    	//Get the double value of the string representation, keeping culture in mind
    	double test = Convert.ToDouble(sVal, CultureInfo.GetCultureInfo(culture));
        
    	//Check to see if the culture-adjusted string is equal to the double
    	if (dVal != test)
    	{
    		//The string conversion isn't correct, so throw an exception
    		throw new System.ArgumentException("dVal doesn't equal sVal for the specified culture");
    	}
                    
    	//Split the string on the separator 
    	string[] segments = sVal.Split(sep);
        
    	switch (segments.Length)
    	{
    		//Only one segment, so there was not fractional value - return 0
    		case 1:
    			return 0;
    
    		//Two segments, so return the length of the second segment
    		case 2:
    			return segments[1].Length;
        
    		//More than two segments means it's invalid, so throw an exception
    		default:
    			throw new Exception("Something bad happened!");
    	}
    }
