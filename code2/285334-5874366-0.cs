    public class TransactionManager
    {
        private ISession session;
    
        public TransactionManager(ISession session)
        {
            this.session = session;
        }
    
        public void BeginTransaction()
        {
             session.BeginTransaction();
        }
    
        public void CommitTransaction()
        {
            session.Transaction.Commit();
        }
    }
