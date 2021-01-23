    public static string DoSomething<T>(Enum value)
    {
    	if (!Enum.IsDefined(typeof(T), value))
    	{
    		value = (T)Enum.ToObject(typeof(T), 0);
    	}
    	// ... do some other stuff
    }
