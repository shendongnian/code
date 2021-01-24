    public List<string> SplitWord(string word)
    {
        // for "woolworkers" would return ["wo", "ol", "workers"]
        var splitted = SplitOnSequences(word);
        
        List<string> result = new List<string>();
        foreach (var sequence in splitted)
        {
            // some rule when to split further
            // for example if the part is larger than three characters
            if (sequence.Length > 3)
            {                                             // some amount of segments
                result.AddRange(SplitInSegments(sequence, sequence.Length / 3 + 1));
            }
            else
            {
                result.Add(sequence);
            }
        }
    
        return result;
    }
