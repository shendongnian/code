    void UpdateDatabase()
    {
    //...
            try 
                { 
         
                } 
                   // Your checks to identify - type of exception
                   // ...
                  // .net exception
                  // Throw your custom exception in the appropriate block - 
                  // throw new DatabaseException();
                catch (OutOfMemoryException ex1) 
                { 
                    
                }
                catch (InvalidDataException ex2) 
                { 
                    
                }
                // Generic exception
                catch (Exception ex3) 
                { 
                    // throw new DatabaseException();
                } 
    //....
    }
    
    // Method calling UpdateDatabase need to handle Custom exception
    void CallUpdateDatabase()
    {
     try
      {
        UpdateDatabase();
      }
      catch(DatabaseException dbEx)
      {
        // Handle your custom exception
      }
    }
