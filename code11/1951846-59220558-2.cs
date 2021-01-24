    public static Attributes operator +(Attributes x, Attributes y)
    {
    	FieldInfo[] info = typeof(Attributes).GetFields();
    	object boxedResult = new Attributes();
    	foreach (FieldInfo fi in info)
    	{
    		fi.SetValue(boxedResult, (int)fi.GetValue(x) + (int)fi.GetValue(y));
    	}
    
    	return (Attributes)boxedResult;
    }
