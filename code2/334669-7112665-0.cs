    public static void FillArray<T>(this T[] array, T value)
    {
        // TODO: Validation
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }
