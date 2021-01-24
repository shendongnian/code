    // sequences to split on first
    static readonly string[] splitSequences = {
        "el",
        "ol",
        "bo"
    };
    
    static readonly string regexDelimiters = string.Join('|', splitSequences.Select(s => "(" + s + ")"));
    
    // Method to split on sequences
    public string[] SplitOnSequences(string word)
    {
        return Regex.Split(word, regexDelimiters).Where(s => !string.IsNullOrEmpty(s)).ToArray();
    }
    
    // Then this is your main code:
    string word = "woolworkers";
    
    // contains ["wo", "ol", "workers"]
    var splitted = SplitOnSequences(word);
    
    List<string> result = new List<string>();
    foreach (var sequence in splitted)
    {
        // some rule when to split further
        if (sequence.Length > 3)
        {                                             // some amount of splits
            result.AddRange(SplitInSegments(sequence, sequence.Length / 3));
        }
        else
        {
            result.Add(sequence);
        }
    }
