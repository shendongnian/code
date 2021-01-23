    public static void RemoveAll<T>(this BindingList<T> list, Func<T, bool> predicate)
    {
    	foreach (var item in list.Where(predicate).ToArray())
    		list.Remove(item);
    }
