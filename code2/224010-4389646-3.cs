    private string _name;
    public string Name 
    {
       get{ return _name;}
       set
       { 
          if( ValidateName(value))
          {
             _name = value;
          }
       }
    }
