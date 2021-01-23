    public void SourceAvailable_Get()
    {
        CallSendGet(pFBlock.SourceAvailable);
    }
    
    private void CallSendGet(object source)
    {
       MethodInfo mi = source.GetType().GetMethod("SendGet");
       if (mi != null)
       {
           ParameterInfo[] piArr = mi.GetParameters();
            if (piArr.Length == 0)
            {
               mi.Invoke(source, new object[0]);
            }
       }
    }
