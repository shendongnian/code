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
    
      // this will NOT be executed
      ReleaseResources();
    }
    public int Bar()
    {
      try
      {
        MethodThatCausesException();
      }
      catch
      {
        return 0;
      }
      finally
      {
        // this will be executed
        ReleaseResources();
      }
    }
