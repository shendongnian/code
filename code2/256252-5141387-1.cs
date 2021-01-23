    public bool TestMethod()
    {
        bool returnValue = false;
        try
        {
           if(true)
           { 
             //some random code
             returnValue = true;
           }       
        }
        catch(Exception ex)
        {
             // log the exception here, or rethrow it
        }
    
        return returnValue;
    }
