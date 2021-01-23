    public int Highest
    {
        get { return Math.Max(_score1, Math.Max(_score2, _score3)); }
    }
    
    public int Lowest
    {
        get { return Math.Min(_score1, Math.Min(_score2, _score3)); }
    }
