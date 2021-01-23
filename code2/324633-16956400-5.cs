    private static object lockingObject = new object();
    public static LazySample InstanceCreation()
    {
        if(lazilyInitObject == null)
        {
             lock (lockingObject)
             {
                  if(lazilyInitObject == null)
                  {
                       lazilyInitObject = new LazySample ();
                  }
             }
        }
        return lazilyInitObject ;
    }
