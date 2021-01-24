    public bool Check
    {
      get { return _check; }
      set
      {
        // here you can add your logic,
        // If this logic is common for every field, you
        // can wrap it in method and call it here.
        // Also here you can use variable named "value", which holds
        // value to be set.
        // At the end, set the value:
        _check = value;
      }
    }
