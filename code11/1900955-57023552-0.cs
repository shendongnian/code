    public static void FillWith<T>(this List<T> list, T value)
    {
        for (var i = 0, i < list.Count, i++)
        {
            list[i] = value;
        }
    }
    
