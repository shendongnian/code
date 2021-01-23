    try 
    {
        SomeFunc()
    }
    catch( Exception exa)
    {
        if(exa.Message == "ErrType 1")
        {
            DoStuff;
        }
        if(exa.Message == "ErrType 2")
        { 
             Die();
         }
    }
