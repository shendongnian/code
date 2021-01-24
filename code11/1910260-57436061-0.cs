    public static string[] SplitInSegments(string word, int segments)
    {
        while(word.Length %  segments != 0) { word+=" ";}
        var result = new List<string>();
        for(int x=0; x < word.Count(); x += word.Length / segments)
        result.Add((new string(word.Skip(x).Take(word.Length / segments).ToArray()).Trim()));
        return result.ToArray();
    }
