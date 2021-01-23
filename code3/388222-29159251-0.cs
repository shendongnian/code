    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly TKey key;
        private readonly IEnumerable<TElement> values;
        public Grouping(TKey key, IEnumerable<TElement> values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            this.key = key;
            this.values = values;
        }
        public TKey Key
        {
            get { return key; }
        }
        public IEnumerator<TElement> GetEnumerator()
        {
            return values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
