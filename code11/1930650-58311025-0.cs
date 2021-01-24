    void DoIt(string pathIn, IEnumerable<int> lineNumbers, string pathOut)
    {
      var lines = new HashSet<int>(lineNumbers);
      var dict = File.ReadAllLines(pathIn)
        .Select((lineText, index) => KeyValuePair<int, string>(index, lineText))
        .Where(p => lines.Contains(p.Key))
        .ToDictionary(p => p.Key, p => p.Value);
      File.WriteAllLines(pathOut, lineNumbers.Select(i => dict[i]));
    }
