    public bool selected { 
      get {
        ...
      }
      set {
        ...
        PropertyChanged("selected");
        PropertyChanged("IsDone");
      }
    }
