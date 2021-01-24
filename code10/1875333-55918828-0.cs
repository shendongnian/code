    using System.Transactions;
    
    using (var transactionScope = new TransactionScope())
    {
      // your db operations ...
      
      transactionScope.Complete();
    }
