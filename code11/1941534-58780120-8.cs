    public delegate void ParameterizedActionWithParams(params object[] parameters);
    public void MyAction(ParameterizedActionWithParams action, params object[] parameters)
    {
      if ( action != null )
        action(parameters);
      else
        ManageArgumentNullException();
    }
