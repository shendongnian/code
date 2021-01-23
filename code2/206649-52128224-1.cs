    // Check if its not null or empty
    if (!IsNullOrEmpty(val.ToString().ToArray()))
    {
        // Do something with val
        dt.Rows.Add(val);
    }
    
    public static bool IsNullOrEmpty<T>(T[] array)
    {
        return array == null || array.Length == 0;
    }
