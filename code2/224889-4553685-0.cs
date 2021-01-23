    private string _name;
    
    public string Name
    {
      get {
        if (_name == null)
        {
          name = string.Empty;
        }
        return _name;
      }
      set {_name = value;}
    }
