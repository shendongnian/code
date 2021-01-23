	static void Main(string[] args)
    {
        var required = new int[]
                           {
                               0*9 + 1,
                               0*9 + 9,
                               1*9 + 1,
                               1*9 + 9,
                               2*9 + 1,
                               2*9 + 9,
                               3*9 + 1,
                               3*9 + 2,
                               3*9 + 3,
                               3*9 + 4,
                               3*9 + 5,
                               3*9 + 6,
                               3*9 + 7,
                           };
        precomputed = required.Select((x, i) => new { Value = x, Offset = (UInt16)(1 << i) }).ToDictionary(x => x.Value, x => x.Offset);
        for (int i = 0; i < required.Length; i++)
        {
            precomputedResult |= (UInt16)(1 << i);
        }
        int[] array = new int[34]; // your array goes here..
        Console.WriteLine(ContainsList(array));
        Console.ReadKey();
    }
    // precompute dictionary
    private static Dictionary<int, UInt16> precomputed;
    // precomputed result
    private static UInt16 precomputedResult = 0;
    public static bool ContainsList(int[] values)
    {
        UInt16 result = 0;
        for (int i = 0; i < values.Length; i++)
        {
            UInt16 v;
            if (precomputed.TryGetValue(values[i], out v))
                result |= v;
        }
        return result == precomputedResult;
    }
