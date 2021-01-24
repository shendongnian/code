    public delegate void ParameterizedActionWithList(List<object> parameters);
    public void MyAction(ParameterizedActionWithList action, List<object> parameters)
    {
      if ( action != null )
        action(parameters);
      else
        ManageArgumentNullException();
    }
