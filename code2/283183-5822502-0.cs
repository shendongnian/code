    IEnumerable<string> GetNamespacesUsed(string fileName)
    {
        var lines = System.IO.File.ReadAllLines(fileName);
        var usingLines = lines.Where(
            x => x.StartsWith("using ") && !x.StartsWith("using ("));
        foreach (var line in usingLines)
        {
            if (line.Contains("="))
                yield return line.Substring(line.IndexOf("="), line.Length - 1);
            else
                yield return line.Substring(line.Length - 1);
        }
    }
