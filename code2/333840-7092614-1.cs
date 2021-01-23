    private string name;
    public string Name { 
      get {
        if (null != FriendlyName)
          return FriendlyName;
        else
          return name;
        }
      set {
        name = value;
      }
    }
