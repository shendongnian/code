    DisposableObjectA disposableA = null;
    DisposableObjectB disposableB = null;
    DisposableObjectC disposableC = null;
    ...
    
    try
    {
        disposableA = new DisposableObjectA();
        ....
    }
    finally
    {
         if (disposableA != null)
         {
              disposableA.Dispose();
         }
    
         if (disposableB != null)
         {
              disposableB.Dispose();
         }
    
         //and so on
    }
