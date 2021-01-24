    public class MyList<T> : IEnumerable<T>
    {
        IQueryable<T> queryable;
        public MyList(IQueryable<T> ts)
        {
            this.queryable = ts;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.Queryable;
        }
        ...
    }
