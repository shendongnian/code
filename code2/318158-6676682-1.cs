    public static void Test(Delegate delegateToTest)
    {
       if (X.EventX != null)
       {
           foreach (Delegate existingHandler in X.EventX.GetInvocationList())
           {
               if (existingHandler == delegateToTest)
               {
                   // registered
               }
           }
        }
    }
