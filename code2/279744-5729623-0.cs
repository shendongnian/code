    public static bool Equals<T>(object value, T value) : T is Enum
    {
   	if(value != null)
	{
    		return false;
    	}
    	int i;
    	if(int.TryParse(value, out i))
    	{
    		return i == value;
    	}
    	return false;
    }
