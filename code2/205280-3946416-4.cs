    static IEnumerable<string> segment(string text)
    {
        if (text == "") return new string[0]; // C# idiom for empty list of strings
        var candidates = from pair in splits(text)
                         select new[] {pair.Item1}.Concat(segment(pair.Item2));
        return candidates.OrderBy(Pwords).First();
    }
