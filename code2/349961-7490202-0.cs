    using(TransactionScope scope = new TransactionScope())
    {
       try
       {
          // Your code here
    
          // If no errors were thrown commit your transaction
          scope.Complete();          
       }
       catch
       {
          // Some error handling
       }
    }
