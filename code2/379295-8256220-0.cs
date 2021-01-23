    public int UsualProperty 
    {
      get { return this._usualProperty; }
      set
      {
        this._usualProperty = value;
        this.OnPropertyChanged("UsualProperty");
        // And notify that the CalculatedProperty changed too
        this.OnPropertyChanged("CalculatedProperty");
      }
    }
    public int CalculatedProperty
    {
      get { return this.UsualProperty * 2; }
    }
