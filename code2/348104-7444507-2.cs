    private IList<string> _list = new List<string>();
    
    public IEnumerable<string> List
    {
      get
      {
        ///return _list;
         return _list.ToList();
      }
    }
