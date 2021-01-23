	public bool IsNumber(String value)
	{
	    double d;
	    if (string.IsNullOrWhiteSpace(value)) 
			return false; 
		else 		
	    	return double.TryParse(value.Trim(), System.Globalization.NumberStyles.Any,
								System.Globalization.CultureInfo.InvariantCulture, out d);
	}
