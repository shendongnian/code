    public void SourceAvailable_Get()
    {
        CallMethod(pFBlock.SourceAvailable);
    }
    
    private void CallMethod(object source, String methodName = "SendGet")
    {
       MethodInfo mi = source.GetType().GetMethod(methodName);
       if (mi != null)
       {
            if (mi.GetParameters().Length == 0)
            {
               mi.Invoke(source, new object[0]);
            }
       }
    }
