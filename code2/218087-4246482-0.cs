    private void MasterGet(PFBlock pFBlock, string propertyName)
    {
        Type t = pFBlock.GetType();
        
        // Cycle through the properties.
        foreach (PropertyInfo p in t.GetProperties())
        {
             if(p.Name == propertyName)
             {
               MethodInfo mi = p.GetType().GetMethod("SendGet");
                  if (mi != null)
                  {
                     ParameterInfo[] piArr = mi.GetParameters();
                     if (piArr.Length == 0)
                      {
                          mi.Invoke(p, new object[0]);
                      }
                  }
             }
        }
    }
