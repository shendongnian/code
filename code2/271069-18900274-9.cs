    private int backingFieldForMyProperty;
    public int MyProperty 
    {
      get 
      {
        Contract.Ensures(Contract.Result<int>() >= 0);
        return this.backingFieldForMyProperty;
      }
    
      private set 
      {
        Contract.Requires(value >= 0);
        this.backingFieldForMyProperty = value;
      }
    }
    [ContractInvariantMethod]
    private void ObjectInvariant () 
    {
      Contract.Invariant ( this.backingFieldForMyProperty >= 0 );
    ...
