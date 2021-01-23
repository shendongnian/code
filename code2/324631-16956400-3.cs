    public static LazySample InstanceCreation()
    {
        private static object lockingObject = new object();
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
