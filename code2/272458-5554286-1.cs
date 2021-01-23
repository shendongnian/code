    class Factory
    {
      ISomeService service;
      public Factory(ISomeService service)
      {
        this.service = service;
      }
    
    
      public SomeObject CreateItem(object runtimeDependency)
      {
        return new SomeObject(service, runtimeDependency);
      }
    }
