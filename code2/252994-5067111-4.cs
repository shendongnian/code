    // If the container's Resolve method had an overload that 
    // accepted a System.Type, it would be even easier.
    public SomeBaseType GetTable()
    {
       var repositoryType = typeof(IRepository<>).MakeGenericType(GetType());
     
       var result = _container.GetType()
                              .GetMethod("Resolve")
                              .MakeGenericMethod(repositoryType)
                              .Invoke(_container, null);
       return (SomeBaseType) result;     
    }
