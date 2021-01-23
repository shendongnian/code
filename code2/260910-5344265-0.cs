    class UnitOfWork : IDisposable
    {
       ...
       public void DoInTransaction(Action<ISession> method)
       {
           Open session, begin transaction, call method, and then commit. Roll back if there was an exception.
       }
    }
