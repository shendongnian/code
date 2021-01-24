    public static class Ext
    {
        public static void FillArray(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }
        }
        public static void FillArray(this bool[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = false;
            }
        }
    }
