    public class FilteredEnumerator<T> : IEnumerable<T>
    {
        public FilteredEnumerator(IQueryable queryable)
        {
             this.queryable = queryable;
        }
        private readonly IQueryable queryable;
        private IEnumerator<T> GetEnumerator()
        {
            return this.queryable.OfType<T>();
        }
    }
