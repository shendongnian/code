    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index)
        {
            return new PagedList<T>(source.AsQueryable(), index, 10);
        }
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source.AsQueryable(), index, pageSize);
        }
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new PagedList<T>(source, index, 10);
        }
    }
