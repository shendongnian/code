    public static void BubbleSort<T>(this T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length-1; j++)
            {
                if (arr[j - 1].CompareTo(arr[j]) > 0)
                    swap(arr[j - 1], arr[j]);
            }
        }
    }
