    void RootMethod()
    {
         using(TransactionScope scope = new TransactionScope())
         {
              /* Perform transactional work here */
              SomeMethod();
              SomeMethod2();
              SomeMethod3();
              scope.Complete();
         }
    }
