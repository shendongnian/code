    public static class Ext
    {
        public static void FillArray<T>(this T[] array)
        {
            Type itemType = typeof(T);
            T value;
            if (itemType == typeof(bool))
            {
                value = (T)Convert.ChangeType(false, itemType);
            }
            else if (itemType == typeof(int))
            {
                value = (T)Convert.ChangeType(-1, itemType);
            }
            else
            {
                value = default(T);
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
    }
