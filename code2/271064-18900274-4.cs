    public int MyProperty { get; private set ;}
    
    [ContractInvariantMethod]
    private void ObjectInvariant ()
    {
      Contract.Invariant ( this .MyProperty >= 0 );
    }
    
