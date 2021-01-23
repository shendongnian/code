    private List<Bar> _bar = new List<Bar>();
    public IEnumerable<Bar> Bar 
    {
        get { return _bar.ToArray(); }
    }
