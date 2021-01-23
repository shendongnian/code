    public static T[] RemoveAt<T>(T[] array, int index) // hope there are not bugs, wrote by scratch.
	{
		int count = array.Length - 1;
		T[] result = new T[count];
		
		if (index > 0)
			Array.Copy(array, 0, result, 0, index - 1);
		if (index < size)
			Array.Copy(array, index + 1, result, index, size - index);
		
		return result;
	}
	
	...
	strItems = RemoveAt(strItems, index);
	
