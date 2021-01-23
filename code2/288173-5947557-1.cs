    string _value;
    
    public string MyProperty 
    {
      get{return _value;}
      set {
       if (Enum.GetName(typeof(MyEnum), _value)==null) 
          throw new ArgumentException("Unknown Value")
       _value=value;
       }
    }
