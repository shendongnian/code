    MySomethingDoerSpringProvider: IMySomethingDoerProvider
    {
      IList<ICustomInterfaceThatDoesSomething> GetAll() 
      {
        // use Spring.Context.Support.ContextRegistry.GetContext()
        //                  .GetObjectsOfType(typeof (ICustomInterfaceThatDoesSomething));
      }
    }
