    public bool Method1(String manyArgs, ...)
    {
      .. some logic ..
      if(!successful)
         MethodToShowError(someString_1)
      return successul;
    }
    
    public bool Method2(String manyArgs, ...)
    {
      .. some logic ..
      if(!successful)
         MethodToShowError(someString_2)
      return successul;
    }
    
    public bool Method3(String manyArgs, ...)
    {
      .. some logic ..
      if(!successful)
         MethodToShowError(someString_3)
      return successul;
    }
    
    public bool Method4(String manyArgs, ...)
    {
      .. some logic ..
      if(!successful)
         MethodToShowError(someString_4)
      return successul;
    }
    
    ... your frame construct ...
    
    if (Method_1(String manyArgs, ...) &&
        Method_2(String manyArgs, ...) &&
        Method_3(String manyArgs, ...) &&
        Method_4(String manyArgs, ...))
    {
        ...
    }
