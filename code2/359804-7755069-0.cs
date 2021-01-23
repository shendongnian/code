    private SomeClass _someRef = null;
    public SomeClass SomeRef
    {
      get
      {
        if(_someRef == null)
        {
           //initialisation just in case of access
           _someRef = new  SomeClass();
        }
        return _someRef;
      }
    }
