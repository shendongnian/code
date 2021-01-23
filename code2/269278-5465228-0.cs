    using( var transaction = session.BeginTransaction() ) 
    {
          repository.Save (entity); 
    
          transaction.Commit();   // error, exception is thrown.
    }
    
    NonTransactionalCode (entity); // this line will not be executed, since the exception will be thrown up the stack until a suitable catch block is encountered.
