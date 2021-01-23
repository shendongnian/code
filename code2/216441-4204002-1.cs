    private readonly Dictionary<string, int> _myDictionary 
                      = new Dictionary<string, int>();
    protected virtual IDictionary<string, int> MyDictionary 
    {
       get
       {
          return _myDictionary; 
       }
    }
