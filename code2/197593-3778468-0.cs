    public void processSomeRequest()
    {
    
       string firstVariable = null;
       string secondVariable = null;
       int someInt = 0;
    
       try
       {
           // Initialise variables
           firstVariable = "test";
           secondVariable = "blah";
           // Process request code
       }
       catch(Exception e)
       {
           logException(e);
           throw;
       }
    
    }
