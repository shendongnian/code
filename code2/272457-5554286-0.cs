    class Factory
    {
      public Factory(ISomeService service)
      {}
    
    
      public SomeObject CreateItem(object runtimeDependency)
      {
        return new SomeObject(service, runtimeDependency);
      }
    }
