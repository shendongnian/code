    string strBig = "Retrieves a substring from this instance. The substring starts at a specified character position.";
    IEnumerable<string> subwords = strBig.Split('.')
        .Where(x => x.Length > 0)
        .Select(x => x.Trim());
    foreach (var subword in subwords)
    {
        Console.WriteLine(subword);
    }
