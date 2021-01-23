    class UnitOfWork : IDisposable
    {
       ISession _session;
       ITransation _transaction;
       bool _commitTried;
       // stuff goes here
       void Commit()
       {
          _commitTried = true;
          _transaction.Commit();
       }
       void Dispose()
       {
          if (!_commitTried) _transaction.Rollback();
          _transaction.Dispose();
          _session.Dispose();
       }
    }
