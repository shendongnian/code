    public delegate void ParameterizedMethodWithList(List<object> parameters);
    public void MyMethod(ParameterizedMethodWithList method, List<object> parameters)
    {
      if ( method != null )
        method(parameters);
      else
        ManageArgumentNullException();
    }
