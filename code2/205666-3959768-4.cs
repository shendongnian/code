    public string SplitAsWords(string original)
    {
        var str = Regex.Replace(original, "[a-z][A-Z]", 
            new MatchEvaluator(match => match.Value.ToLower().Insert(1, " ")));
        
        return str;
    }
