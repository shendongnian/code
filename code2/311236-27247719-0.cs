    public static Decimal GetInvariantDecimal(string Value)
    {
        try
        {
        	Decimal d = 0;
        	if (Decimal.TryParse(Value, out d))
        		return d;
        	else
        		return Convert.ToDecimal(Value, System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
        	throw ex;
        }
    }
