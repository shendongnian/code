    private static readonly Tuple<int, int, bool> NameOfCase1 = 
        Tuple.Create(1, 1, false);
    private static readonly Tuple<int, int, bool> NameOfCase2 =
        Tuple.Create(2, 1, false);
    private static readonly Tuple<int, int, bool> NameOfCase3 =
        Tuple.Create(2, 2, false);
    private static readonly Dictionary<Tuple<int, int, bool>, string> Results =
        new Dictionary<Tuple<int, int, bool>, string>
    {
        { NameOfCase1, "Result 1" },
        { NameOfCase2, "Result 2" },
        { NameOfCase3, "Result 3" }
    };
    public string GetResultForValues(int x, int y, bool b)
    {
        const string defaultResult = "Unknown";
        var lookupValue = Tuple.Create(x, y, b);
        string result;
        Results.TryGetValue(lookupValue, out result);
        return defaultResult;
    }
