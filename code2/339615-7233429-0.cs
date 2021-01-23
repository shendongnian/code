    private bool isEmptyInstance;    
    public bool SomeMethodThatReturnsABoolean()
    {
      if (isEmptyInstance) { return false; }
      // rest of the method
    }
