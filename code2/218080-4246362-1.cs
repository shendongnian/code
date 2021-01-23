    private void Source_Get( Object source )
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
    
    public void SourceInfo_Get()
        {
           Source_Get(pFBlock.SourceInfo);
        }
    
    public void SourceAvailable_Get()
        {
           Source_Get(pFBlock.SourceAvailable)
        }
