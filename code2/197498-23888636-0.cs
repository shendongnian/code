    public IEnumerable<string> SplitCSV(string input)
    {
        Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
    
        foreach (Match match in csvSplit.Matches(input))
        {
            yield return match.Value.TrimStart(',');
        }
    }
