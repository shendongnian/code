    public int Foo()
    {
      try
      {
        MethodThatCausesException();
      }
      catch
      {
        return 0;
      }
    
      // this method will NOT be executed
      ReleaseResources();
    }
