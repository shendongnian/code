    public UserControl CreateObject<T>(string objectName) where T : class
    {
        ///// create object code abbreviated here
         UserControl NewControl = createcontrol(objectName);
    
         if (NewControl is T)
              return NewControl;
         else
              throw new SystemException("Requested object does not implement required interface");
    }
