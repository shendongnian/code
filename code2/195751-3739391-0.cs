    private string _mystring;
    public string MyString
    {
      get {return _mystring;}
      set 
      {
          if (IsAcceptableInput(value))
             _mystring = value;
      }
    }
