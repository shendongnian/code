    private IList<string> _someList = new List<string>();
    
    public void Add(string item){ _someList.Add(item); }
    public string Remove(string item) { return _someList.Remove(item); }
    ...
