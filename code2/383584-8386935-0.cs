    public bool IsValid
    {
      get
      {
        ...
      }
    }
    public void SomeMethod()
    {
      Contract.Ensures(this.IsValid == Contract.OldValue(this.IsValid));
      ...
    }
