    public static int[] FewUnique(int uniqueCount, int low, int high, int returnSize)
    {
        Random r = _random;
        int[] values = new int[uniqueCount];
        for (int i = 0; i < uniqueCount; i++)
        {
            values[i] = r.Next(low, high);
        }
        int[] array = new int[returnSize];
        for (int i = 0; i < returnSize; i++)
        {
            array[i] = values[r.Next(0, values.Count())];
        }
        return array;
    }
