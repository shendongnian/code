    public T Get<T>(string val)
    {
    	if (!string.IsNullOrWhiteSpace(val))
    		return (T) TypeDescriptor.GetConverter(typeof (T)).ConvertFromString(val);
    	else 
    		return default(T);
    }
