    public interface IRepository<T>
    {
        IQueryable<T> All();
        IQueryable<T> Sorted(Func<T, object> sort1, Func<T, object> sort2 = null, Func<T, object> sort3 = null);
    }
    public class Repository<T> : IRepository<T>
    {
        public IQueryable<T> All()
        {
            // TODO: Implement real data retrieval
            return new List<T>().AsQueryable();
        }
        public IQueryable<T> Sorted(Func<T, object> sort1, Func<T, object> sort2 = null, Func<T, object> sort3 = null)
        {
            var list = All();
            var res = list.OrderBy(sort1);
            if (sort2 != null)
                res = res.ThenBy(sort2);
            if (sort3 != null)
                res = res.ThenBy(sort3);
            return res.AsQueryable();
        }
    }
