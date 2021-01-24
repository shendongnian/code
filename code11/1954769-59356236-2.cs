    static void Main(string[] args)
    {
        var (a, b) = GetMultipleValue();
        Tuple<int, int> tuple = GetMultipleValue();
    }
    public static Tuple<int, int> GetMultipleValue()
    {
        return Tuple.Create(1, 2);
    }
