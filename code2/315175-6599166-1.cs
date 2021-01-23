    public static void FastRemoveAll<T>(this BindingList<T> list, Func<T, bool> predicate)
    {
    	for (int i = list.Count - 1; i >= 0; i--)
    		if (predicate(list[i]))
    			list.RemoveAt(i);
    }
