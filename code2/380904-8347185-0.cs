    public void SomeMethod(SomeClass x)
    {
      if (x == null) throw new ArgumentNullException("x");
      Contract.EndContractBlock();
      ...
    }
