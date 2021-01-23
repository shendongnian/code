    public static void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
    public static void InsertionSort<T>(this T[] a) where T : IComparable<T>
    {
        a.InsertionSort(Comparer<T>.Default.Compare);
    }
    public static void InsertionSort<T>(this T[] a, Comparison<T> c)
    {
        int n = a.Length;
        for (int i = 1; i < n; ++i)
            for (int k = i; k > 0 && c(a[k], a[k - 1]) < 0; --k)
                Swap(ref a[k], ref a[k - 1]);
    }
