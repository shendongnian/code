	public bool IsNumber(String value)
	{
        double d;
		if (string.IsNullOrWhiteSpace(value)) { return false; }
		if (double.TryParse(value.Trim(), System.Globalization.NumberStyles.Any, 
                            System.Globalization.CultureInfo.InvariantCulture, out d) 
			== false) { return false; }
		return true;
	}
