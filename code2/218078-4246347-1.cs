    public void SourceInfo_Get()    
    {
        SendGet(pFBlock.SourceInfo);
    }
    public void SourceAvailable_Get()
    {
        SendGet(pFBlock.SourceAvailable);
    }
    private void SendGet(Object obj) {
        MethodInfo mi = obj.GetType().GetMethod("SendGet");
        if (mi != null)
        {
            ParameterInfo[] piArr = mi.GetParameters();
            if (piArr.Length == 0)
            {
                mi.Invoke(obj, new object[0]);
            }
        }
    }
