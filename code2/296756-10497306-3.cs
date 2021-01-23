    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
    	decimal convertedDecimal;
    	if (!decimal.TryParse((string)value, out convertedDecimal))
    	{
    		return new ValidationResult(false, "My Custom Message"));
    	}
    	else
    	{
    		return new ValidationResult(true, null);
    	}
    }
