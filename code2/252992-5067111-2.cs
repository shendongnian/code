    // If the container accepted a Resolve method that 
    //  accepted a System.Type, it would be even easier.
    public SomeBaseType GetTable()
    {
       var repositoryType = typeof(IRepository).MakeGenericType(GetType());
     
       var result = _container.GetType()
                              .GetMethod("Resolve")
                              .MakeGenericMethod(repositoryType)
                              .Invoke(_container, null);
       return (SomeBaseType) result;     
    }
