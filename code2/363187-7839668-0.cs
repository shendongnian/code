    public object Add(IConvertible a, IConvertible b)
    {
    	if(IsNumeric(a) && IsNumeric(b))
    		return a.ToDouble(CultureInfo.InvariantCulture) + b.ToDouble(CultureInfo.InvariantCulture);
    	return a.ToString() + b.ToString();
    }
    
    public static bool IsNumeric(object o)
    {
    	var code = (int)Type.GetTypeCode(o.GetType());
    	return code >= 4 && code <= 15;
    }
