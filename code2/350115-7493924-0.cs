    public bool Foo()
    {
      try
      {
        return SomeFunctionMightThrow();
      }
      catch (Exception ex)
      {
        LogAndThrow(ex);
        return false; //will never get here
      }
    }
