    public static string ArraySort(string input)
    {
        return $"{input.Substring(0, 2)}{input.Substring(7, 1)}{input.Substring(3, 5)}";
    }
    public static void Main(string[] args)
    {
        string[] ar = new string[] { "DV00154A", "DV00144A", "DV00111B", "DV00100A", "DV00199B", "DV00001A" };
        Array.Sort(ar, (a, b) => StringComparer.OrdinalIgnoreCase.Compare(ArraySort(a), ArraySort(b)));
        Console.WriteLine(string.Join(",", ar));
        Console.ReadKey();
    }
