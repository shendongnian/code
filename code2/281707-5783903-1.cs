    public static void BubbleSort<T>(this T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length-1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                    swap(arr[j], arr[j + 1]);
            }
        }
    }
