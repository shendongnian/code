    private String _username;
    
    protected void setUserName(String argUsername);
    {
      if (_username != Username) // an overload of String.Compare would be better here
      {
        _username = value;
        // Do the stuff you have to do because username has changed
      }
    }
    
    public String Username {get {return _username;} protected set {setUsername(value);}}
