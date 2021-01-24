    public static T[] RemoveAt(T[] items, int X)
	{
		T[] result = new T[items.Count() - 1];		
		
		int indexOfLastResult = 0;
		for (int i = 0; i < items.Count(); i++)
		{
			if (i != X)
			{
			 	result[indexOfLastResult] = items[i];				
				indexOfLastResult++;
			}
		}
		
		return result;
	}
