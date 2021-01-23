    public string _firstName;
    public string Firstname 
    { 
      get { return this._firstName; }
      set
      {
        this._firstName = value;
        this.UpdateModifiedTimestamp();
      }
    }
