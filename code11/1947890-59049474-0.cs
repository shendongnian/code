    public static void PushElement<T>(ref T[,] arr, int index, T value)
    {
        var len1 = arr.GetLength(1);
        Array.Copy(arr, index * len1, arr, index * len1 + 1, len1 - 1);
        arr[index, 0] = value;
    }
    public static void Main()
    {
        int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };
        PushElement(ref arr, 1, 7);
