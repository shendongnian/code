    public bool IsValid
    {
      get 
      { 
        if (!isValidated)
           Validation();
        return isValid;
      }
      private set { isValid = value; }
    }
    public string Foo
    {
      get { return foo; }
      set 
      {
        foo = value;         
        isValidated := false;
      }
    }
