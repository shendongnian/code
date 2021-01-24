    private bool _b1;
    public bool B1
    {
     get
      {
      return _b1;
      }
    set
     {
      _b1 = value;
      if(value)
      {
       _b2 = false;
       _b3 = false;
      }
     }
    }
    
    private bool _b2;
    public bool B2
     {
     get
      {
      return _b2;
      }
     set
      {
      _b2 = value;
      if(!value)
       {
       SomethingUnrelated();
       }
      }
     }
    
    private bool _b3;
    public bool B3
     {
     get
      {
      return _b3;
      }
     set
      {
      _b3 = value;
      if(value)
       {
       _b1 = true;
       }
     }
    }
