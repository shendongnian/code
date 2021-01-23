    static void Main(string[] args)
    {
        var major = new[] { 0, 2, 4, 5, 7, 8, 11 };
        var text = new StringBuilder();
    
        text.AppendLine(Print(GetChords(major, 5)));   // triads
        text.AppendLine(Print(GetChords(major, 7)));   // 7ths
        text.AppendLine(Print(GetChords(major, 9)));   // 9ths
        text.AppendLine(Print(GetChords(major, 11)));  // 11ths
        text.AppendLine(Print(GetChords(major, 13)));  // 13ths
    
        var rendered = text.ToString();
        Console.WriteLine(rendered);
    
        Console.ReadKey();
    }
    
    static string Print(IEnumerable<IEnumerable<int>> chords)
    {
        return string.Join(",", chords.Select(chord => string.Join(" ", chord.Select(x => x))));
    }
