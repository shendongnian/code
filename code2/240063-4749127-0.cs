    private readonly List<string> _list = new List<string>();
    
    public IEnumerable<string> Values // Adding is not allowed - only iteration
    {
       get { return _list; }
    }
