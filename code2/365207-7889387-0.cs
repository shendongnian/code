        try 
        {
             //Call Method
             subtract(1.0,2.0);
        }
        catch (Exception ex)
        {
           throw new FaultException(ex.Message);
           // Or display a message box.  
        }
