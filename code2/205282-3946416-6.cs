    static Dictionary<string, IEnumerable<string>> segmentTable =
       new Dictionary<string, IEnumerable<string>>();
    static IEnumerable<string> segment(string text)
    {
        if (text == "") return new string[0]; // C# idiom for empty list of strings
        if (!segmentTable.ContainsKey(text))
        {
            var candidates = from pair in splits(text)
                             select new[] {pair.Item1}.Concat(segment(pair.Item2));
            segmentTable[text] = candidates.OrderBy(Pwords).First().ToList();
        }
        return segmentTable[text];
    }
