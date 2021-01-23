    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where);
        void Save(T item);
        void SubmitChanges();
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Save(T item)
        {
        }
        public void SubmitChanges()
        {
        }
    }
