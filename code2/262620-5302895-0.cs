    public void Replace(string input)
    {
        Regex r = new Regex(@"(/[^/]*)");
        var matchEval = new MatchEvaluator(Encode);
        r.Replace(input, matchEval);
    }
    
    public string Encode(Match m)
    {
        //TODO: Encode the match
    }
