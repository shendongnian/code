    public string Property1
    {
        set 
        {
          if(value == null)
          {
            throw new ArgumentNullException();
          } 
          instance1.property1 = value;
        }
    }
