    private static string _filename;
    public static string Filename
    {
      get
      {
        if(_filename==null)
          throw new InvalidOperationException("Filename not set");
        return _filename;
      }
      set
      {
        if(_filename!=null)
          throw new InvalidOperationException("Filename set twice");
        _filename=value;
      }
    }
