    public class SelectList<T>
    {
        public SelectList(IEnumerable<T> source,
                          Func<T, string> idProjection,
                          Func<T, string> displayProjection)
        {
            ...
        }
    }
