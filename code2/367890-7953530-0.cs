    public static string Concat(params string[] values)
    {
    	int num = 0;
    	if (values == null)
    	{
    		throw new ArgumentNullException("values");
    	}
    	string[] array = new string[values.Length];
    	for (int i = 0; i < values.Length; i++)
    	{
    		string text = values[i];
    		array[i] = ((text == null) ? string.Empty : text);
    		num += array[i].Length;
    		if (num < 0)
    		{
    			throw new OutOfMemoryException();
    		}
    	}
    	return string.ConcatArray(array, num);
    }
