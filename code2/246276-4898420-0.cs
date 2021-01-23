    // Base class
    protected int InternalID {get; set;}
    
    // Derived class
    [XmlElement]
    public int SomethingID
    {
      get {return InternalID;}
      set {InternalID = value;}
    }
