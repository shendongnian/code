    public static void Main(string[] args)
    {
        var results = FindSubsets("123456789", 3);
        Console.Read();
    }
    public static List<string> FindSubsets(string data, int level)
    {
        if (level > data.Length || level < 1)
            return null;
        var results = new List<string>();
        for (int i = 0; i < data.Length - level + 1; i++)
        {
            var str = data.Substring(i, level);
            results.Add(str);
        }
        return results;
    }
