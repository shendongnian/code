    static int[] a = { 0, 10, 20, 30, 40 };
    public static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            int[] array = (int[])a.Clone();
            for (int j = 1; j < array.Length; j++)
                array[j] += array[j-1];
            Console.WriteLine(array[4]);
        }
    }
