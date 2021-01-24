    public delegate void ParameterizedMethodWithParams(params object[] parameters);
    public void MyMethod(ParameterizedMethodWithParams method, params object[] parameters)
    {
      if ( method != null )
        method(parameters);
      else
        ManageArgumentNullException();
    }
