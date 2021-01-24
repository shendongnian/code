    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        int Save();
    }
