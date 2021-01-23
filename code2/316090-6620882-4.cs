    public class NHUnitofWork<T> : IUnitofWork<T> where T : EntityBase
    {
    protected INHSessionBuilder SessionBuilder { get; private set; }
    public NHPersistorBase(INHSessionBuilder sessionBuilder)
    {
      SessionBuilder = sessionBuilder;
    }
    public T Get(int id)
    {
      T result = null;
      ISession session = SessionBuilder.GetSession();
      using (ITransaction transaction = session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
      {
        try
        {
          result = (T)session.Get(typeof(T), id);
          transaction.Commit();
        }
        finally
        {
          if (transaction.IsActive)
            transaction.Rollback();
        }
      }
      return result;
    }
    public IQueryable<T> Find()
    {
      return SessionBuilder.GetSession().Query<T>();
    }
}
