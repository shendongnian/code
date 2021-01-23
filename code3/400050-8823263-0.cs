    public class DataProvider
    {
        public int AddEntity<TEntity>(TEntity entity)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                try
                {
                    int newId = (int)_session.Save(entity);
                    _session.Flush();
                    tx.Commit();
                    return newId;
                }
                catch (NHibernate.HibernateException)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }    
    }
