    public static List<T> ConvertToList<T>(ArrayList list)
    {
        if (list == null)
            throw new ArgumentNullException("list");
    
        var newList = new List<T>(list.Count);
    
        for (int i = 0; i < list.Count; i++)
            newList[i] = (T)list[i];
    
        return newList;
    }
