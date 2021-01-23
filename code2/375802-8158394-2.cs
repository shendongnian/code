    public static string outputDictionaryContents(Dictionary<string, int> list)
    {
        return string.Join(
             Console.Out.NewLine,
             list.Select(pair => string.Format("{0}, {1}", pair.Key, pair.Value)).ToArray());
    }
