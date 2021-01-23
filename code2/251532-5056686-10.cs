    MySomethingManager
    {
      public MySomethingManager() {}
      
      public MySomethingManager(IMySomethingDoerProvider prov) 
      { // init SomethingDoers }
      IList<ICustomInterfaceThatDoesSomething> SomethingDoers { get; set; }
      void SignalAllToDoSomething()
      {
        foreach (var doer in Provider.SomethingDoers )
          doer.DoSomething();
      }
    }
    IMySomethingDoerProvider
    {
      IList<ICustomInterfaceThatDoesSomething> GetAll();
    }
