    // Note: start is inclusive, end is exclusive (as is conventional
    // in computer science)
    public static void Fill<T>(T[] array, int start, int end, T value)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        if (start < 0 || start >= end)
        {
            throw new ArgumentOutOfRangeException("fromIndex");
        }
        if (end >= array.Length)
        {
            throw new ArgumentOutOfRangeException("toIndex");
        }
        for (int i = start; i < end; i++)
        {
            array[i] = value;
        }
    }
