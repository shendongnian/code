    char[] validChars = Enumerable.Range(0, 26).Select(i => (char)('A' + i)).ToArray();
    List<string> result = new List<string>();
    List<string> generator = validChars.Select(ch => ch.ToString()).ToList();
    
    int n = 1000;
    
    while (result.Count < n)
    {
        result.AddRange(generator);
        generator = generator.SelectMany(s => validChars.Select(ch => s + ch)).ToList();
    }
    
    var output = result.Take(n);
