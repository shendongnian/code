    static void Main(string[] args)
    {
        int[] values = { 10, 20, 20, 10, 30 };
        int[] keys = { 1, 2, 3, 4, 5 };
        int[] indexes = Enumerable.Range(0, values.Length).ToArray();
        Array.Sort(indexes, (i1, i2) => Compare(i1, i2, values, keys));
        // Use the index array directly to access the original data
        for (int i = 0; i < values.Length; i++)
        {
            Console.WriteLine("{0}: {1}", values[indexes[i]], keys[indexes[i]]);
        }
        Console.WriteLine();
        // Or go ahead and copy the old data into new arrays using the new order
        values = OrderArray(values, indexes);
        keys = OrderArray(keys, indexes);
        for (int i = 0; i < values.Length; i++)
        {
            Console.WriteLine("{0}: {1}", values[i], keys[i]);
        }
    }
    private static int Compare(int i1, int i2, int[] values, int[] keys)
    {
        int result = values[i1].CompareTo(values[i2]);
        if (result == 0)
        {
            result = keys[i1].CompareTo(keys[i2]);
        }
        return result;
    }
    private static int[] OrderArray(int[] values, int[] indexes)
    {
        int[] result = new int[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            result[i] = values[indexes[i]];
        }
        return result;
    }
