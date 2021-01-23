    public static List<T> ConvertToList<T>(ArrayList list)
    {
        if (list == null)
            throw new ArgumentNullException("list");
    
        List<T> newList = new List<T>(list.Count);
    
        foreach (object obj in list)
            newList.Add((T)obj);
        // If you really don't want to use foreach:
        // for (int i = 0; i < list.Count; i++)
        //     newList.Add((T)list[i]);
    
        return newList;
    }
