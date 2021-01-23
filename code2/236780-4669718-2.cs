    public class GeneralRepository<TEntity, TContext> : IRepository<TEntity>
    {
        protected abstract Table<TEntity> GetTable(TContext dc);
        public void Add(Treatment item)
        {
            using (TContext dc = new TContext())
            {
                GetTable(dc).InsertOnSubmit(item);
                dc.SubmitChanges();
            }
        }
        // and so on for other methods
    }
