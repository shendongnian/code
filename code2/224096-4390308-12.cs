    public static void Main()
    {
        var comparer = new StringNumberComparer();
        List<string> testStrings = new List<string>{
            "3.9.5.2.1.1",
            "3.9.5.2.1.10",
            "3.9.5.2.1.11",
            "3.9.test2",
            "3.9.test",
            "3.9.5.2.1.12",
            "3.9.5.2.1.2",
            "blabla",
            "....",
            "3.9.5.2.1.3",
            "3.9.5.2.1.4"};
        testStrings.Sort(comparer);
        DumpArray(testStrings);
        Console.Read();
    }
    private static void DumpArray(List<string> values)
    {
        foreach (string value in values)
        {
            Console.WriteLine(value);
        }
    }
