    public string[] tokenizer(string input, string splitExp)
    {
        string noWSpaceInput = Regex.Replace(input, @"\s", "");
        Console.WriteLine(noWSpaceInput);
        Regex RE = new Regex(splitExp);
        return (RE.Split(noWSpaceInput)).Where(x => !string.IsNullOrEmpty(x)).ToArray();
    }
