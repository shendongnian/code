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
    
