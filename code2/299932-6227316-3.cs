    DisposableObjectA disposableA = null;
    DisposableObjectB disposableB = null;
    DisposableObjectC disposableC = null;
    ...
    
    try
    {
        disposableA = new DisposableObjectA();
        try
        {
            disposableB = new DisposableObjectB();
   
            // Try/catch block with disposableC goes here.
        }
        finally
        {
             if (disposableB != null)
             {
                  disposableB.Dispose();
             }    
        }
    }
    finally
    {
         if (disposableA != null)
         {
              disposableA.Dispose();
         }    
    }
