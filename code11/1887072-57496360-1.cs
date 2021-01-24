    public interface Database
    {
        DatabaseResult DoQuery(DbQuery query);
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        bool IsInTransaction();
    }
