    static void Main(string[] args)
    {
        Dictionary<int, string> source = new Dictionary<int, string>();
        source.Add(3, "foo");
        source.Add(4, "bar");
        DumpDic(source);
        DumpDic(MirrorDictionary(source));
        Console.ReadLine();
    }
