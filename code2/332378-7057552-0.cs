    private bool _isCommitted;
    
    public bool IsCommitted
    {
      get { return _isCommitted; }
      set
      {
         if(value)
         {
            //do something
         }
    
         _isCommitted = value;
      }
    }
